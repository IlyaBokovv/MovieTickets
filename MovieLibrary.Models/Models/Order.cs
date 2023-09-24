using MovieLibrary.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Models.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";
        public string TransactionKey { get; set; } = "";
        public OrderStatus OrderStatus { get; set; } = OrderStatus.OnGoing;

        public string UserId { get; set; } = "";
        public AppUser AppUser { get; set; } = new AppUser();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem> { };
        public decimal GetTotalPrice()
        {
            return OrderItems.Sum(x => x.Price);
        }
        public string GetOrderStatusAsString()
        {
            if (OrderStatus == OrderStatus.OnGoing)
            {
                return "On Going";
            }
            else
            {
                return "Done";
            }
        }
    }
}
