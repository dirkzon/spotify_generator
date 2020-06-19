using SpotifyGenerator.Domain.interfaces;
using System.Collections.Generic;

namespace SpotifyGenerator.Logic.services
{
    public class QuestionService : IQuestionService
    {
        private readonly string[] Attributes = { "acousticness", "danceability", "energy", "liveness", "instrumentalness" };
        public List<double> Answers = new List<double>();

        //voegt een antwoord to aan de lijst
        public double AddAnswerToList(double answer, int index)
        {
            Answers.Add(answer);
            return answer;
        }
        //geeft een attribute aan de hand van de index
        public string GetAttributeByIndex(int index)
        {
            return Attributes[index];
        }
        //geeft alle antwoorden
        public IReadOnlyCollection<double> GetAnswers()
        {
            return Answers;
        }
    }
}
