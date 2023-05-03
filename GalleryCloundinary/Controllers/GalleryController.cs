using GalleryCloundinary.Data;
using GalleryCloundinary.Services;
using GalleryCloundinary.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GalleryCloundinary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IImageService _imageService;
      
        public GalleryController(IImageService imageService)
        {
            _imageService = imageService;
        }
        [HttpGet("GalleryIndex")]
        public IActionResult GalleryIndex()
        {
            var imageList = _imageService.GetAll();

            var model = new GalleryIndexModel()
            {
                Images = imageList,
                SearchQuery = ""
            };
            return Ok(model);

        }
    }
}
