using GalleryCloundinary.Services;
using GalleryCloundinary.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace GalleryCloundinary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ICloudinaryImageUpload _cloudinaryImageUpload;

        public ImageController(ICloudinaryImageUpload cloudinaryImageUpload)
        {
            _cloudinaryImageUpload = cloudinaryImageUpload;
        }
        [HttpPost]

        public async Task<IActionResult> UploadNewImage([FromForm]UploadImageModel model)
        {
            await Console.Out.WriteLineAsync("Img:::::"+model);
            return Ok(model);
            //return Ok(model.UploadImage);
            //await _cloudinaryImageUpload.UploadPicture(model);
            //return RedirectToAction("GalleryIndex", "Gallery");

        }
    }
}
