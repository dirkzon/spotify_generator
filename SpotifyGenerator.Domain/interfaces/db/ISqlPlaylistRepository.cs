using SpotifyGenerator.Domain.DataTransferObjects;
using System.Collections.Generic;

namespace SpotifyGenerator.Domain.interfaces
{
    public interface ISqlPlaylistRepository
    {
        public IEnumerable<DbPlaylistDTO> GetPlaylistsByAmount(int amount);
        public DbPlaylistDTO SavePlaylistInDb(DbPlaylistDTO playlist);
    }
}
