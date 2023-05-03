using GalleryCloundinary.Models;
using Microsoft.EntityFrameworkCore;

namespace GalleryCloundinary.Data
{
    public class GalleryDbContext : DbContext
    {
        public GalleryDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<ImageTag> ImageTags { get; set; }
    }
}
