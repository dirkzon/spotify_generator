using SpotifyGenerator.Domain.DataTransferObjects;
using System.Threading.Tasks;

namespace SpotifyGenerator.Domain.interfaces
{
    public interface IUserRepository
    {
        public Task<UserDTO> GetUser(string token);
    }
}
