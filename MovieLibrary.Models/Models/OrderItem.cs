using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Models.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public int MovieId { get; set; }
        public int OrderId { get; set; }

        public Movie Movie { get; set; } = new Movie();
        public Order Order { get; set; } = new Order();
    }
}
