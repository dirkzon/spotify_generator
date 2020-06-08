using SpotifyGenerator.Domain.DataTransferObjects;
using System.Threading.Tasks;


namespace SpotifyGenerator.Domain.interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> CreateUser(string token);
    }
}
