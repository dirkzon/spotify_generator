using Newtonsoft.Json.Linq;
using SpotifyGenerator.Domain.interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyGenerator.ApiWrapper.apiaccess
{
    public class TokenRepository : ITokenAccess
    {
        private readonly HttpClient _client;

        public TokenRepository(IHttpClientFactory clientFactory)
        {
            if (clientFactory != null)
            {
                _client = clientFactory.CreateClient("SpotifyAuthorization");
            }
        }

        public async Task<string> GetAccessToken(string code, string redirect)
        {
            HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("redirect_uri", redirect),
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
            });
            var response = await ApiContext.Post<JObject>(_client ,"/api/token" , content);
            return response["access_token"].ToString();
        }
    }
}
