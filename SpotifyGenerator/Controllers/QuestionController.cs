using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpotifyGenerator.Domain.interfaces;
using SpotifyGenerator.Domain.interfaces.db;
using SpotifyGenerator.Logic;
using System.Linq;

namespace SpotifyGenerator.Controllers
{
    public class QuestionController : Controller
    {
        static int index;
        IQuestionService questionService;
        ISqlQuestionRepository sqlQuestionRepository;
        IConfiguration Configuration;

        public QuestionController(IQuestionService questionService, ISqlQuestionRepository sqlQuestionRepository, IConfiguration config)
        {
            this.sqlQuestionRepository = sqlQuestionRepository;
            this.questionService = questionService;
            Configuration = config;
        }

        public IActionResult Index()
        {
            index = 0;
            return View();
        }

        //haalt vraag uit de database, als de gebruiker vijf vragen heeft beantwoordt wordt de gebruiker doorgestuurd
        public IActionResult GetQuestion()
        {
            if (index < 5)
            {
                var questionmodel = sqlQuestionRepository.GetQuestionByAttribute(questionService.GetAttributeByIndex(index));
                if (questionmodel.Type == "Button")
                {
                    return PartialView("ButtonBox", questionmodel);
                }
                return PartialView("SliderBox", questionmodel);
            }
            HttpContext.Session.SetObjectAsJson("Answers", questionService.GetAnswers());
            return SpotifyLogIn();
        }

        //stuurt de gebruiker naar een pagina van Spotify waar hij/zij in kan loggen
        public IActionResult SpotifyLogIn()
        {
            QueryBuilder qb = new QueryBuilder();
            qb.Add("response_type", "code");
            qb.Add("client_id", Configuration["Authorization:ClientId"]);
            qb.Add("scope", "user-read-private playlist-modify-private playlist-modify-public streaming app-remote-control");
            qb.Add("redirect_uri", Configuration["Authorization:Redirect"]);
            string url = "https://accounts.spotify.com/authorize/" + qb.ToQueryString();
            return Json(new {redirect = url });
        }

        //genereert de waarde van het antwoord aan de hand van de input en het algoritme en voegt deze waarde toe aan een lijst
        public void NextQuestion(double input)
        {
            var answer = Algorithm.GetValue(questionService.GetAnswers().ToList(), input);
            questionService.AddAnswerToList(answer, index);        
            index++;
        }
    }
}
