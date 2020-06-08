using System.Collections.Generic;

namespace SpotifyGenerator.Logic.models
{
    public class Playlist
    {
        public List<Track> Tracks { get; set; } = new List<Track>();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public string GetUris()
        {
            string Uris = string.Empty;
            foreach (Track track in Tracks)
            {
                Uris += track.Uri + ",";
            }
            return Uris;
        }

        public void RemoveTrack(string songid)
        {
            Tracks.RemoveAll(track => track.Id == songid);
        }
    }
}
