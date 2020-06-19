    using SpotifyGen.Domain;
using System;

namespace SpotifyGenerator.Domain.DataTransferObjects
{
    public class ArtistDTO
    {
        public ExternalUrls external_urls { get; set; }
        public string name { get; set; }
        public string? id { get; set; }
        public Followers? followers { get; set; }
        public long? popularity { get; set; }
        public Image[]? images { get; set; }

        public partial class Image
        {
            public Uri url { get; set; }
        }

        public partial class Followers
        {
            public long total { get; set; }
        }
    }
}
