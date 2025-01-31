using ltImageGallery.Models;
using ltImageGallery.Services;
using Microsoft.AspNetCore.Mvc;

namespace ltImageGallery.Controllers
{
    public class ImagesController : Controller
    {
        private readonly AlbumService _albumService;

        public ImagesController(AlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        [Route("album/grid")]
        public async Task<IActionResult> PhotoGrid(int albumId = 0, string searchValue = "")
        {
            List<Photo> photos = new List<Photo>();

            if (albumId > 0)
            {
                //get photos for the specific album
                photos = await _albumService.GetPhotosByAlbum(albumId) ?? new List<Photo>();
            } else if (searchValue != "")
            {
                //first get all album detail which contains all photos
                List<Album> albums = await _albumService.GetAlbums() ?? new List<Album>();

                if (albums != null && albums.Count > 0)
                {
                    //filter down to just the photos that contain the search text in photo title or url
                    photos = albums.SelectMany(x => x.photos).Where(z => (z.title != null && z.title.Contains(searchValue, StringComparison.OrdinalIgnoreCase)) ||
        (z.url != null && z.url.Contains(searchValue, StringComparison.OrdinalIgnoreCase))).ToList();
                }
            }

            return View(photos);
        }

        [HttpGet]
        [Route("album/slide")]
        public async Task<IActionResult> PhotoSlide(int albumId)
        {
            //get photos for the specific album
            List<Photo> photos = await _albumService.GetPhotosByAlbum(albumId) ?? new List<Photo>();
            return View(photos);
        }
    }
}
