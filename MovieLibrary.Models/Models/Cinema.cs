using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MovieLibrary.Models.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public int ImageId { get; set; }

        public IEnumerable<Movie>? Movies { get; set; } = new List<Movie>();
        public Image Image { get; set; } = Image.DefaultImageFactory();
    }
}
