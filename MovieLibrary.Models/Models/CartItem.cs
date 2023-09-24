using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Models.Models
{
    public class CartItem : IEntityBase
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public int CartId { get; set; }
        public int MovieId { get; set; }

        public Movie Movie { get; set; } = new Movie();
        public Cart Cart { get; set; } = new Cart();
    }
}
