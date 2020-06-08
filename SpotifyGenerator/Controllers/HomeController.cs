using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpotifyGenerator.Domain.interfaces;

namespace SpotifyGenerator.Controllers
{
    public class HomeController : Controller
    {
        ISqlPlaylistRepository playlistRepository;
        IConfiguration Configuration;

        public HomeController(ISqlPlaylistRepository repository, IConfiguration config)
        {
            playlistRepository = repository;
            Configuration = config;
        }

        public IActionResult Index()
        {
            var model = playlistRepository.GetPlaylistsByAmount(5);
            return View(model);
        }

        public IActionResult SpotifyLogIn()
        {
            QueryBuilder qb = new QueryBuilder();
            qb.Add("response_type", "code");
            qb.Add("client_id", Configuration["Authorization:ClientId"]);
            qb.Add("scope", "user-read-private playlist-modify-private playlist-modify-public streaming app-remote-control");
            qb.Add("redirect_uri", Configuration["Authorization:Redirect"]);
            string url = "https://accounts.spotify.com/authorize/" + qb.ToQueryString();
            return Redirect(url);
        }
    }
}
