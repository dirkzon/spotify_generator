using SpotifyGenerator.Domain.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyGenerator.Domain.interfaces
{
    public interface IArtistService
    {
        public Task<List<ArtistDTO>> SearchForArtist(string artistname, string token);

        public ArtistDTO AddArtistToList(ArtistDTO artistdto);
        public string RemoveArtistById(string artistid);
        public string GetAllArtistIds();
        public List<ArtistDTO> GetAllArtists();
    }
}
