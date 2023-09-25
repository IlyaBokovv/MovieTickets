using MovieLibrary.Models.Models;
using MovieLibrary.Services.Interfaces;
using Microsoft.Extensions.Hosting;


namespace MovieLibrary.Services.Services
{
    public class ImageUploadService : IImageUploadService
    {
        private readonly IHostEnvironment _hostEnvironment;

        public ImageUploadService(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public void Delete(string imagePath)
        {
            string destinationOnServer = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot" + "/", imagePath);
            if (File.Exists(destinationOnServer))
            {
                File.Delete(destinationOnServer);
            }
        }
        public async Task<string> UploadAsync(Image image, string imageId)
        {
            string wwwRootPath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot");
            string extension = Path.GetExtension(image.ImageFile!.FileName);

            string fileName = imageId + '-' + DateTime.Now.ToString("yymmssfff") + extension;

            string destinationOnServer = Path.Combine(wwwRootPath + "/images/", fileName);
            using (var fileStream = new FileStream(destinationOnServer, FileMode.Create))
            {
                await image.ImageFile.CopyToAsync(fileStream);
            }
            return "images/" + fileName;
        }
    }
}
