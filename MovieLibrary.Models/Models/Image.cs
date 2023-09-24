using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Models.Models
{
    public class Image : IEntityBase
    {
        private static string defaultImagePath = "images/default_image.jpg";
        public int Id { get; set; }
        public string ImagePath { get; set; } = defaultImagePath;
        public IFormFile? ImageFile { get; set; }

        public static Image DefaultImageFactory()
        {
            return new Image() { ImagePath = defaultImagePath };
        }
    }
}
