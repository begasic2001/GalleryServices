namespace GalleryCloundinary.ViewModels
{
    public class UploadImageModel
    {
        public string Title { get; set; }
        public IFormFile UploadImage { get; set; }
        public IFormFile UploadImage2 { get; set; }
        public IFormFile UploadImage3 { get; set; }
        public string Tags { get; set; }
    }
}
