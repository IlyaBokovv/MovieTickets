using Microsoft.EntityFrameworkCore;
using MovieLibrary.DataAccess;
using MovieLibrary.Models.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Services.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _db;

        public CartService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Cart?> AddMovieToCartAsync(int movieId, string userId, string email)
        {
            var cartTask = _db.Carts
                .Where(c => c.UserId == userId && c.Email == email)
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync();

            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);

            var movie = await _db.Movies.FirstOrDefaultAsync(m => m.Id == movieId);


            var cart = cartTask.Result;

            if (user == null)
            {
                return null;
            }

            if (movie == null)
            {
                return cart;
            }
            var cartItem = new CartItem()
            {
                MovieId = movieId,
                Amount = 1,
                Price = movie.Price,
                Movie = movie
            };
            if (cart != null)
            {
                var oldCartItem = cart.CartItems.FirstOrDefault(ci => ci.MovieId == movieId);
                if (oldCartItem != null)
                {
                    oldCartItem.Amount++;
                    oldCartItem.Price += movie.Price;
                }
                else
                {
                    cart.CartItems.Add(cartItem);
                }
                _db.Carts.Entry(cart).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return cartTask.Result;
            }
            cart = new Cart
            {
                CartItems = new List<CartItem> { cartItem },
                UserId = userId,
                Email = email,
                AppUser = user
            };
            cartItem.Cart = cart;
            await _db.Carts.AddAsync(cart);
            await _db.SaveChangesAsync();
            return cart;
        }
        public async Task<Cart?> RemoveMovieFromCartAsync(int movieId, string userId, string email)
        {
            var cart = await _db.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Movie)
                .FirstOrDefaultAsync(c => c.Email == email && c.UserId == userId);
            var movie = cart!.CartItems.FirstOrDefault(ci => ci.Movie.Id == movieId);

            if (movie == null || cart == null)
            {
                return null;
            }
            var cartItem = cart.CartItems.FirstOrDefault(c => c.MovieId == movieId);

            if (cartItem!.Amount == 1)
            {
                _db.CartItems.Remove(cartItem);
            }
            else
            {
                cartItem!.Amount--;
                _db.Carts.Entry(cart).State = EntityState.Modified;
            }
            await _db.SaveChangesAsync();
            return cart;
        }
        public async Task<Cart?> GetUserCartAsync(string userId, string email)
        {
            var cart = await _db.Carts
               .Where(c => c.UserId == userId && c.Email == email)
               .Include(c => c.CartItems)
               .ThenInclude(ci => ci.Movie)
               .FirstOrDefaultAsync();
            return cart;
        }
    }
}
