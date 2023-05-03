using GalleryCloundinary.ViewModels;

namespace GalleryCloundinary.Services
{
    public interface ICloudinaryImageUpload
    {
        Task<string> UploadPicture(UploadImageModel model);
    }
}
