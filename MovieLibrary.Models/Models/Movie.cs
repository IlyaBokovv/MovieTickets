using MovieLibrary.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Models.Models
{
    public class Movie : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string Description { get; set; } = "";
        public DateTime StratDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        public int DirectorId { get; set; }
        public int CinemaId { get; set; }
        public int ImageId { get; set; }

        public IEnumerable<ActorMovie> ActorsMovies { get; set; } = new List<ActorMovie>();
        public Director Director { get; set; } = new Director();
        public Cinema Cinema { get; set; } = new Cinema();
        public Image Image { get; set; } = Image.DefaultImageFactory();
    }
}
