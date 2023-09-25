using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.DataAccess.Configurations;
using MovieLibrary.Models.Models;

namespace MovieLibrary.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActorConfiguirations());
            modelBuilder.ApplyConfiguration(new ActorsMoviesConfigurations());
            modelBuilder.ApplyConfiguration(new MovieConfigurations());
            modelBuilder.ApplyConfiguration(new CinemaConfigurations());
            modelBuilder.ApplyConfiguration(new DirectorConfigurations());
            modelBuilder.ApplyConfiguration(new OrderConfigurations());
            modelBuilder.ApplyConfiguration(new OrderItemConfigurations());
            modelBuilder.ApplyConfiguration(new CartConfigurations());
            modelBuilder.ApplyConfiguration(new CartItemConfigurations());
            modelBuilder.ApplyConfiguration(new ImageConfigurations());
            modelBuilder.ApplyConfiguration(new UserAddressConfigurations());
            base.OnModelCreating(modelBuilder);
        }
    }
}
