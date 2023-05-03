using GalleryCloundinary.Models;

namespace GalleryCloundinary.ViewModels
{
    public class GalleryIndexModel
    {
        public IEnumerable<GalleryImage> Images { get; set; }
        public string SearchQuery { get; set; }
    }
}
