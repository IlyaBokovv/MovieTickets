using MovieLibrary.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetUserOrdersAsync(string userId, string email);
        Task<Order> OrderAsync(Cart cart, string transactionKey);
        Task<List<Order>> GetOrdersWithUsersAsync();
        public Task MarkAsDone(int id);

    }
}
