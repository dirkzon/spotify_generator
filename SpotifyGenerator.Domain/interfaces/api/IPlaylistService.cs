using SpotifyGen.Domain;
using SpotifyGenerator.Domain.DataTransferObjects;
using System.Threading.Tasks;

namespace SpotifyGenerator.Domain.interfaces
{
    public interface IPlaylistService
    {
        public Task<PlaylistDTO> CreatePlaylist(string playlistname, int limit, string artistid, string token, double[] answers);
        public Task<DbPlaylistDTO> PostPlaylist(UserDTO user, string token);
        public string RemoveTrack(string trackid);
    }
}
