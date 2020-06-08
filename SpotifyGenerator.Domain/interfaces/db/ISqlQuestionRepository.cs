using SpotifyGenerator.Domain.DataTransferObjects;

namespace SpotifyGenerator.Domain.interfaces.db
{
    public interface ISqlQuestionRepository
    {
        public DbQuestionDTO GetQuestionByAttribute(string Attribute);
    }
}
