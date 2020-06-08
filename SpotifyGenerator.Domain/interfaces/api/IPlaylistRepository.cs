using SpotifyGen.Domain;
using SpotifyGen.Domain.DTO;
using SpotifyGenerator.Domain.DataTransferObjects;
using System.Threading.Tasks;

namespace SpotifyGenerator.Domain.interfaces
{
    public interface IPlaylistRepository
    {
        public Task<PlaylistDTO> CreatePlaylist(int limit, string artistid, string token, double[] answers);
        public  Task<string> PostPlaylist(PostPlaylistDTO playlist, UserDTO user, string token);
    }
}
