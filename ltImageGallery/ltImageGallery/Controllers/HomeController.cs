using System.Diagnostics;
using ltImageGallery.Models;
using ltImageGallery.Services;
using Microsoft.AspNetCore.Mvc;

namespace ltImageGallery.Controllers
{
    public class HomeController : Controller
    {
        private readonly AlbumService _albumService;

        public HomeController(AlbumService albumService)
        {
            _albumService = albumService;
        }

        public async Task<IActionResult> Index()
        {
            List<Album> albums = await _albumService.GetAlbums() ?? new List<Album>();

            if (albums != null && albums.Count >0)
            {
                //sort by id for OCD :)
                albums = albums.OrderBy(x => x.albumId).ToList();
            }

            return View(albums);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
