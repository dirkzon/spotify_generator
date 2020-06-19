using SpotifyGenerator.Domain.DataTransferObjects;
using SpotifyGenerator.Domain.interfaces;
using SpotifyGenerator.Logic.models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyGenerator.Logic.services
{
    public class ArtistService : IArtistService
    {
        private IArtistRepository _artistRepository;

        public List<Artist> Artists { get; set; } = new List<Artist>();

        public ArtistService ()
	    {
	    }

        public ArtistService(IArtistRepository repository)
        {
            _artistRepository = repository;
        }

        //naar artiesten zoeken aan de hand van een naam
        public async Task<List<ArtistDTO>> SearchForArtist(string artistname, string token)
        {
            var artistlist = await _artistRepository.SearchArtist(artistname, token);
            return artistlist.Take(5).Where(artist => artist.popularity > 35).ToList();
        }

        //een artiest toeveogen aan de lijst van artiesten
        public ArtistDTO AddArtistToList(ArtistDTO artistdto)
        {
            Artist artist = new Artist
            {
                Artistid = artistdto.id,
                ArtistName = artistdto.name
            };
            Artists.Add(artist);
            return artistdto;
        }

        //een artiest uit de lijst halen aan de hand van de id
        public string RemoveArtistById(string artistid)
        {
            Artists.RemoveAll(artist => artist.Artistid == artistid);
            return artistid;
        }

        //alle id's van de ariesten in een string zetten
        public string GetAllArtistIds()
        {
            string artistids = string.Empty;
            foreach (var artist in Artists)
            {
                artistids += artist.Artistid + ",";
            }
            return artistids;
        }

        //geeft een lijst van artiesten
        public List<ArtistDTO> GetAllArtists()
        {
            var artistreturnlist = new List<ArtistDTO>();
            foreach (var artist in Artists)
            {
                var dto = new ArtistDTO { name = artist.ArtistName, id = artist.Artistid };
                artistreturnlist.Add(dto);
            }
            return artistreturnlist;
        }
    }
}
