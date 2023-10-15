using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using MovieLibrary.DataAccess;
using MovieLibrary.Models.Models;
using MovieLibrary.Services.Interfaces;
using MovieLibrary.Services.Services;
using Services.Interfaces;

namespace MovieLibraryWeb.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIndentity(this IServiceCollection services)
        {
            services
            .AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddRoleValidator<RoleValidator<IdentityRole>>();
            return services;
        }
        public static IServiceCollection AddAuthethicationAndAuthorization(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });
            services.AddAuthorization();
            return services;
        }

        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {
            services.AddScoped<IImageUploadService, ImageUploadService>();
            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<ICinemaService, CinemaService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IActorService, ActorService>();
            return services;
        }
    }
}
