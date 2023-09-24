using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Models.Models
{
    public class Cart : IEntityBase
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";

        public string UserId { get; set; } = "";

        public AppUser AppUser { get; set; } = new AppUser();
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();


        public decimal GetTotalPrice()
        {
            return CartItems.Sum(x => x.Price);
        }

    }
}
