using SpotifyGenerator.Domain.DataTransferObjects;
using SpotifyGenerator.Domain.interfaces.db;
using System.Linq;

namespace SpotifyGenerator.Persistence.repositories
{
    public class SqlQuestionRepository : ISqlQuestionRepository
    {
        private readonly AppDbContext _context;

        public SqlQuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        //haalt een vraag uit de database aan de van een attribute
        public DbQuestionDTO GetQuestionByAttribute(string Attribute)
        {
            return _context.Questions.Single(Q =>Q.Attribute == Attribute);
        }
    }
}
