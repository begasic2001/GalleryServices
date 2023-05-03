using GalleryCloundinary.Models;

namespace GalleryCloundinary.Services
{
    public interface IImageService
    {
        IEnumerable<GalleryImage> GetAll();
        IEnumerable<GalleryImage> GetWithTag(string tag);
        GalleryImage GetById(int id);
    }
}
