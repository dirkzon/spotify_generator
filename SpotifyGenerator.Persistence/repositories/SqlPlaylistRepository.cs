using SpotifyGenerator.Domain.DataTransferObjects;
using SpotifyGenerator.Domain.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SpotifyGenerator.Persistence.repositories
{
    public class SqlPlaylistRepository : ISqlPlaylistRepository
    {
        private readonly AppDbContext _context;

        public SqlPlaylistRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DbPlaylistDTO> GetPlaylistsByAmount(int amount)
        {
            return _context.Playlists.Take(amount).OrderByDescending(x => x.CreationDate);
        }

        public DbPlaylistDTO SavePlaylistInDb(DbPlaylistDTO playlist)
        {
            _context.Playlists.Add(playlist);
            _context.SaveChanges();
            return playlist;
        }
    }
}
