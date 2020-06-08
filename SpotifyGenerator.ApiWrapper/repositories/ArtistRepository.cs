using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpotifyGenerator.Domain.DataTransferObjects;
using SpotifyGenerator.Domain.interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyGenerator.ApiWrapper
{
    public class ArtistRepository : IArtistRepository
    {
        private HttpClient _client;

        public ArtistRepository(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("Spotify"); 
        }

        public async Task<IEnumerable<ArtistDTO>> SearchArtist(string name, string token)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await ApiContext.Get<JObject>(_client, $"/v1/search?q={name}&type=artist");
            return JsonConvert.DeserializeObject<IEnumerable<ArtistDTO>>(response["artists"]["items"].ToString());
        }
    }
}
