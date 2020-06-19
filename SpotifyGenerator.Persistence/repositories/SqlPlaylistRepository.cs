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

        //haalt een lijst van eerder gemaakte playlists op uit de database aan de hand van een aantal
        public IEnumerable<DbPlaylistDTO> GetPlaylistsByAmount(int amount)
        {
            return _context.Playlists.Take(amount).OrderByDescending(x => x.CreationDate);
        }

        //slaat de playlist op in de database
        public DbPlaylistDTO SavePlaylistInDb(DbPlaylistDTO playlist)
        {
            _context.Playlists.Add(playlist);
            _context.SaveChanges();
            return playlist;
        }
    }
}
