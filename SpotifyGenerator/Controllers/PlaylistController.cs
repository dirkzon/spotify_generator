using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyGenerator.Domain.DataTransferObjects;
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
        ISqlUserRepository sqlUserRepository;
        static string Token;

        public PlaylistController(IUserService userService, 
            IPlaylistService playlistService, 
            ISqlPlaylistRepository sqlplaylistRepository,
            ISqlUserRepository sqlUserRepository)
        {
            this.userService = userService;
            this.playlistService = playlistService;
            this.sqlplaylistRepository = sqlplaylistRepository;
            this.sqlUserRepository = sqlUserRepository;
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
            if (!sqlUserRepository.CheckIfUserExists(user.id))
            {
                var DbUser = new DbUserDTO{UserId = user.id,UserName = user.display_name};
                sqlUserRepository.SaveUser(DbUser);
            }
            sqlplaylistRepository.SavePlaylistInDb(playlistDTO);
            return Redirect("https://open.spotify.com/playlist/" + playlistDTO.PlaylistId);
        }
    }
}
