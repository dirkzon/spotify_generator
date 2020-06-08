using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpotifyGen.Domain;
using SpotifyGen.Domain.DTO;
using SpotifyGenerator.Domain.DataTransferObjects;
using SpotifyGenerator.Domain.interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyGenerator.ApiWrapper.apiaccess
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly HttpClient _client;

        public PlaylistRepository(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("Spotify");
        }

        public async Task<PlaylistDTO> CreatePlaylist(int limit, string artistid, string token, double[] answers)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            string url = "https://api.spotify.com/v1/recommendations?" +
                         "limit=" + limit +
                         "&seed_artists=" + artistid +
                         "&target_acousticness=" + answers[0].ToString(CultureInfo.InvariantCulture) +
                         "&target_danceability=" + answers[1].ToString(CultureInfo.InvariantCulture) +
                         "&target_energy=" + answers[2].ToString(CultureInfo.InvariantCulture) +
                         "&target_liveness=" + answers[3].ToString(CultureInfo.InvariantCulture) +
                         "&target_instrumentalness=" + answers[4].ToString(CultureInfo.InvariantCulture);
            return await ApiContext.Get<PlaylistDTO>(_client, url);
        }
        
        public async Task<string> PostPlaylist(PostPlaylistDTO playlist, UserDTO user, string token)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var properties = new Dictionary<string, string>
            {
                {"name", playlist.Name},
                {"description", playlist.Description }
            };
            var json = JsonConvert.SerializeObject(properties);
            var content  = new StringContent(json);
            var response = await ApiContext.Post<JObject>(_client, $"https://api.spotify.com/v1/users/{user.id}/playlists", content);

            await ApiContext.Post<JObject>(_client, $"https://api.spotify.com/v1/playlists/{response["id"]}/tracks?uris={playlist.Uris}", null);
            return response["id"].ToString();
        }
    }
}
