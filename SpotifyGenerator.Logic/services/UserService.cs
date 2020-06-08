using SpotifyGenerator.Domain.DataTransferObjects;
using SpotifyGenerator.Domain.interfaces;
using SpotifyGenerator.Logic.models;
using System.Threading.Tasks;

namespace SpotifyGenerator.Logic.services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userAccess;

        public UserService(IUserRepository access)
        {
            _userAccess = access;
        }

        public async Task<UserDTO> CreateUser(string token)
        {
            return await _userAccess.GetUser(token);
        }
    }
}
