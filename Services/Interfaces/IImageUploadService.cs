using MovieLibrary.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Services.Interfaces
{
    public interface IImageUploadService
    {
        public void Delete(string imagePath);
        public Task<string> UploadAsync(Image image, string imageId, string destination);
    }
}
