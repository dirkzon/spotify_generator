using SpotifyGenerator.Domain.DataTransferObjects;
using SpotifyGenerator.Domain.interfaces;

namespace SpotifyGenerator.Persistence.repositories
{
    public class SqlUserRepository : ISqlUserRepository
    {
        private readonly AppDbContext _context;

        public SqlUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbUserDTO GetUser(string id)
        {
            return _context.Users.Find(id);
        }

        public bool CheckIfUserExists(string id)
        {
            var user = GetUser(id);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public DbUserDTO SaveUser(DbUserDTO user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
