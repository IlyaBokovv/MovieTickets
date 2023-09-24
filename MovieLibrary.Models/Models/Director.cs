using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MovieLibrary.Models.Models
{
    public class Director : IEntityBase
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Bio { get; set; } = "";

        public int ImageId { get; set; }

        public IEnumerable<Movie> Movies { get; set; } = new List<Movie>();
        public Image Image { get; set; } = Image.DefaultImageFactory();
    }
}
