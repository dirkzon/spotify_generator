using System.Collections.Generic;

namespace SpotifyGenerator.Domain.interfaces
{
    public interface IQuestionService
    {
        public double AddAnswerToList(double answer, int index);
        public string GetAttributeByIndex(int index);
        public IReadOnlyCollection<double> GetAnswers(); 
    }
}
