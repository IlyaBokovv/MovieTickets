using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Models.Models
{
    public class ActorMovie
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }

        public Movie Movie { get; set; } = new Movie();
        public Actor Actor { get; set; } = new Actor();
    }
}
