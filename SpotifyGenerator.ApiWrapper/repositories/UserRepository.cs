using System.Net.Http;
using System.Threading.Tasks;
using SpotifyGenerator.Domain.DataTransferObjects;
using SpotifyGenerator.Domain.interfaces;

namespace SpotifyGenerator.ApiWrapper
{
    public class UserRepository : IUserRepository
    {
        public HttpClient _client;

        public UserRepository(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("Spotify");
        }

        //info van de gebruiker ophalen
        public async Task<UserDTO> GetUser(string token)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            return await ApiContext.Get<UserDTO>(_client, "/v1/me");
        }
    }
}
