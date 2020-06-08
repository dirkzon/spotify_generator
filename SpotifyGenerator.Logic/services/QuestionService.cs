using SpotifyGenerator.Domain.interfaces;
using System.Collections.Generic;

namespace SpotifyGenerator.Logic.services
{
    public class QuestionService : IQuestionService
    {
        private readonly string[] Attributes = { "acousticness", "danceability", "energy", "liveness", "instrumentalness" };
        public List<double> Answers = new List<double>();

        public double AddAnswerToList(double answer, int index)
        {
            Answers.Add(answer);
            return answer;
        }
        public string GetAttributeByIndex(int index)
        {
            return Attributes[index];
        }
        public IReadOnlyCollection<double> GetAnswers()
        {
            return Answers;
        }
    }
}
