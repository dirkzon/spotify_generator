using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpotifyGenerator.Domain.DataTransferObjects;
using SpotifyGenerator.Domain.interfaces;
using System;
using System.Threading.Tasks;

namespace SpotifyGenerator.Controllers
{
    public class DataController: Controller
    {
        IArtistService artistService;
        ITokenService tokenService;
        IConfiguration Configuration;
        static string Token;

        public DataController(IArtistService artistService, ITokenService tokenService, IConfiguration config)
        {
            this.artistService = artistService;
            this.tokenService = tokenService;
            Configuration = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/callback")]
        public async Task<IActionResult> CreateToken(string code)
        {
            if (Token == null && code != null)
            {
                Token = await tokenService.GetToken(code, Configuration["Authorization:Redirect"]);
                HttpContext.Session.SetString("access_token", Token);
            }
            return View("Index");
        }

        //zoekt voor een artiest
        public async Task<IActionResult> SearchForArtist(string artistname)
        {
            var model = await artistService.SearchForArtist(artistname, Token);
            return PartialView("ArtistSearchList", model);
        }

        //voegt de artiest toe aan de lijst
        public void AddArtist(string artistname, string artistid)
        {
            var dto = new ArtistDTO {name = artistname, id = artistid };
            artistService.AddArtistToList(dto);
        }

        //verwijdert de artiest uit de lijst
        public void RemoveArtist(string artistid)
        {
            artistService.RemoveArtistById(artistid);
        }

        //haalt alle artiesten uit de lijst
        public IActionResult GetAllArtist()
        {
            var model = artistService.GetAllArtists();
            return PartialView("ArtistList", model);
        }

        public IActionResult CreatePlaylist(string name, int amount)
        {
            var artistids = artistService.GetAllArtistIds();
            if (artistids != "")
            {
               return RedirectToAction("Index", "Playlist", new { limit = amount, artistids = artistids, playlistname = name }); 
            }
            return RedirectToAction("Index", "Data");
        }
    }
}
