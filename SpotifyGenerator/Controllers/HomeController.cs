using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpotifyGenerator.Domain.interfaces;

namespace SpotifyGenerator.Controllers
{
    public class HomeController : Controller
    {
        ISqlPlaylistRepository playlistRepository;
        IConfiguration Configuration;

        public HomeController(ISqlPlaylistRepository repository, IConfiguration config)
        {
            playlistRepository = repository;
            Configuration = config;
        }

        public IActionResult Index()
        {
            var model = playlistRepository.GetPlaylistsByAmount(5);
            return View(model);
        }
    }
}
