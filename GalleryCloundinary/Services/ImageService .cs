using GalleryCloundinary.Data;
using GalleryCloundinary.Models;
using Microsoft.EntityFrameworkCore;

namespace GalleryCloundinary.Services
{
    public class ImageService : IImageService
    {
        private readonly GalleryDbContext _ctx;

        public ImageService(GalleryDbContext ctx)
        {
            _ctx = ctx;


        }
        public IEnumerable<GalleryImage> GetAll()
        {
            return _ctx.GalleryImages.Include(x => x.Tags);
        }

        public GalleryImage GetById(int id)
        {
            return GetAll().FirstOrDefault(img => img.Id == id);
        }

        public IEnumerable<GalleryImage> GetWithTag(string tag)
        {
            return GetAll().Where(img => img.Tags.Any(t => t.Description == tag));
        }
    }
}
