using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using GalleryCloundinary.Data;
using GalleryCloundinary.Models;

namespace GalleryCloundinary.Services
{
    public class CloudinaryImageUpload : ICloudinaryImageUpload
    {
     
        private readonly GalleryDbContext _ctx;
        public CloudinaryImageUpload(GalleryDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<string> UploadPicture(ViewModels.UploadImageModel model)
        {

            Account account = new Account(
            "dlypxr5cd",
            "967947526596887",
            "VBEGyxu-0MZHvFjOlJHTyz2KrN4");
            var cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;

            //reads the Image in the IFormFile into a bytes then we convert this to a base64 string
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                model.UploadImage.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }
            string base64 = Convert.ToBase64String(bytes);


            var prefix = @"data:image/png;base64,";
            var imagePath = prefix + base64;

            // create a new ImageUploadParams object and assign the directory name
            var uploadParams = new ImageUploadParams()

            {
                File = new FileDescription(imagePath),
                Folder = "tour"
            };
            // pass the new ImageUploadParams object to the UploadAsync method of the Cloudinary Api


            var uploadResult = await cloudinary.UploadAsync(@uploadParams);
            await Console.Out.WriteLineAsync(uploadResult.SecureUrl.AbsoluteUri);
            // adds the new image to be uploaded to the database
            var image = new GalleryImage()
            {
                Title = model.Title,
                Created = DateTime.Now,
                Url = uploadResult.Url.AbsoluteUri,
                Tags = ParseTags(model.Tags)

            };
            await _ctx.AddAsync(image);
            await _ctx.SaveChangesAsync();

            return uploadResult.SecureUrl.AbsoluteUri;
        }

        private List<ImageTag> ParseTags(string tags)
        {
            return tags.Split(",").Select(tag => new ImageTag
            {
                Description = tag
            }).ToList();

        }

    }
}
