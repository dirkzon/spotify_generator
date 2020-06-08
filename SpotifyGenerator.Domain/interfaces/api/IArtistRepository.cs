using SpotifyGenerator.Domain.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyGenerator.Domain.interfaces
{
    public interface IArtistRepository
    {
        public  Task<IEnumerable<ArtistDTO>> SearchArtist(string name, string token);
    }
}
