using MovieLibrary.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICartService
    {
        Task<Cart?> GetUserCartAsync(string userId, string email);
        Task<Cart?> AddMovieToCartAsync(int movieId, string userId, string email);
        Task<Cart?> RemoveMovieFromCartAsync(int movieId, string userId, string email);
    }
}
