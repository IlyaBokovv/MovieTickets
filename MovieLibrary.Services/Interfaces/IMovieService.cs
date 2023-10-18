using MovieLibrary.DataAccess.Repository.IRepository;
using MovieLibrary.Models.Models;
using MovieLibrary.Models.ViewModels;

namespace MovieLibrary.Services.Interfaces
{
    public interface IMovieService : IRepositoryBase<Movie>
    {
        Task<Movie?> GetByIdWithInclusionAsync(int id);
        Task<Movie> AddMovieVMAsync(MovieVM movieVM);
        Task<Movie?> UpdateMovieVMAsync(MovieVM movieVM);
        public Task RemoveWithImageAsync(int movieId);
    }
}
