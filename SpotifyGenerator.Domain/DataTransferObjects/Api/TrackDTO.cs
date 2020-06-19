using SpotifyGenerator.Domain.DataTransferObjects;

namespace SpotifyGen.Domain
{
    public class TrackDTO
    {
        public ArtistDTO[] artists { get; set; }
        public bool Explicit { get; set; }
        public ExternalUrls external_urls { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string preview_url { get; set; }
        public string  uri { get; set; }
        public Album album { get; set; }

        public partial class Album
        {
            public Image[] images { get; set; }
        }

        public partial class Image
        {
            public string url { get; set; }
        }
    }
}
