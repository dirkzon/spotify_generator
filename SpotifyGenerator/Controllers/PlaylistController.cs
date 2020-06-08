using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyGenerator.Domain.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyGenerator.Controllers
{
    public class PlaylistController : Controller
    {
        IUserService userService;
        IPlaylistService playlistService;
        ISqlPlaylistRepository sqlplaylistRepository;
        static string Token;

        public PlaylistController(IUserService userService, 
            IPlaylistService playlistService, 
            ISqlPlaylistRepository sqlplaylistRepository)
        {
            this.userService = userService;
            this.playlistService = playlistService;
            this.sqlplaylistRepository = sqlplaylistRepository;
        }

        public async Task<IActionResult> Index(string playlistname, int limit, string artistids)
        {
            var answers = HttpContext.Session.GetObjectFromJson<List<double>>("Answers");
            if (answers == null)
            {
                return RedirectToAction("Index", "Question");
            }
            Token = HttpContext.Session.GetString("access_token");
            var playlistmodel = await playlistService.CreatePlaylist(playlistname, limit, artistids, Token, answers.ToArray());
            return View(playlistmodel);
        }

        public void RemoveTrack(string trackid)
        {
            playlistService.RemoveTrack(trackid);
        }

        public async Task<IActionResult> PostPlaylist()
        {
            var user = await userService.CreateUser(Token);
            var playlistDTO = await playlistService.PostPlaylist(user, Token);
            sqlplaylistRepository.SavePlaylistInDb(playlistDTO);
            return Redirect("https://open.spotify.com/playlist/" + playlistDTO.PlaylistId);
        }
    }
}
