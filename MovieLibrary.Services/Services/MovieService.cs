using Microsoft.EntityFrameworkCore;
using MovieLibrary.DataAccess;
using MovieLibrary.DataAccess.Repository;
using MovieLibrary.Models.Models;
using MovieLibrary.Models.Static;
using MovieLibrary.Models.ViewModels;
using MovieLibrary.Services.Exceptions;
using MovieLibrary.Services.Interfaces;
using NuGet.Packaging.Signing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Services.Services
{
    public class MovieService : RepositoryBase<Movie>, IMovieService
    {
        private readonly ApplicationDbContext _db;
        private readonly IImageUploadService _imageUploadService;

        public MovieService(ApplicationDbContext db, IImageUploadService imageUploadService) : base(db)
        {
            _db = db;
            _imageUploadService = imageUploadService;
        }

        public async Task<Movie> AddMovieVMAsync(MovieVM movieVM)
        {
            var director = await _db.Directors.FirstOrDefaultAsync(d => d.Id == movieVM.DirectorId);
            var cinema = await _db.Cinemas.FirstOrDefaultAsync(d => d.Id == movieVM.CinemaId);
            if (director is null)
            {
                throw new DirectorByIdNotFoundException(movieVM.DirectorId);
            }
            if (cinema is null)
            {
                throw new CinemaByIdNotFoundException(movieVM.DirectorId);
            }
            var movie = new Movie
            {
                Name = movieVM.Name,
                Price = movieVM.Price,
                Description = movieVM.Description,
                StratDate = movieVM.StartDate,
                EndDate = movieVM.EndDate,
                MovieCategory = movieVM.MovieCategory,
                DirectorId = movieVM.DirectorId,
                Director = director,
                CinemaId = movieVM.CinemaId,
                Cinema = cinema
            };
            movie.Image.ImageFile = movieVM.Image.ImageFile;
            if (movie.Image.ImageFile != null)
            {
                var imagePath = await _imageUploadService.UploadAsync(movie.Image, nameof(Movie) + movie.Name, ImageType.Movies);
                movie.Image.ImagePath = imagePath;
            }
            await _db.Movies.AddAsync(movie);
            var actors = await _db.Actors
            .Where(a => movieVM.ActorIds.Contains(a.Id))
            .ToListAsync();
            foreach (var actor in actors)
            {
                var actorMovie = new ActorMovie
                {
                    ActorId = actor.Id,
                    MovieId = movie.Id,
                    Movie = movie,
                    Actor = actor
                };
                await _db.AddAsync(actorMovie);
            }
            _db.SaveChanges();
            return movie;
        }

        public async Task<Movie?> UpdateMovieVMAsync(MovieVM movieVM)
        {
            var oldMovie = await GetByIdWithInclusionAsync(movieVM.Id);
            if (oldMovie == null)
            {
                return null;
            }
            var existingActorMovies = oldMovie.ActorsMovies!.Where(am => am.MovieId == oldMovie.Id);
            _db.ActorMovies.RemoveRange(existingActorMovies);
            await _db.SaveChangesAsync();

            oldMovie.Id = movieVM.Id;
            oldMovie.Name = movieVM.Name;
            oldMovie.Price = movieVM.Price;
            oldMovie.Description = movieVM.Description;
            oldMovie.StratDate = movieVM.StartDate;
            oldMovie.EndDate = movieVM.EndDate;
            oldMovie.MovieCategory = movieVM.MovieCategory;
            oldMovie.DirectorId = movieVM.DirectorId;
            oldMovie.CinemaId = movieVM.CinemaId;

            if (movieVM.Image.ImageFile != null)
            {
                var newImage = new Image() { ImageFile = movieVM.Image.ImageFile };
                newImage.ImagePath = await _imageUploadService.UploadAsync(newImage, nameof(Movie) + oldMovie.Name, ImageType.Movies);
                await _db.Images.AddAsync(newImage);
                await _db.SaveChangesAsync();

                oldMovie.ImageId = newImage.Id;

                _db.Images.Remove(oldMovie.Image);
                oldMovie.Image = newImage;
            }
            await _db.SaveChangesAsync();

            var actors = await _db.Actors
            .Where(a => movieVM.ActorIds.Contains(a.Id))
            .ToListAsync();
            foreach (var actor in actors)
            {
                var actorMovie = new ActorMovie
                {
                    ActorId = actor.Id,
                    MovieId = oldMovie.Id,
                    Movie = oldMovie,
                    Actor = actor
                };
                await _db.ActorMovies.AddAsync(actorMovie);
            }
            _db.SaveChanges();
            return oldMovie;
        }

        public async Task<Movie?> GetByIdWithInclusionAsync(int id)
        {
            var query = _db.Movies.AsQueryable()
                .Include(m => m.Image)
                .Include(m => m.Director)
                .Include(m => m.Cinema)
                .Include(m => m.ActorsMovies)
                .ThenInclude(am => am.Actor)
                .ThenInclude(a => a.Image);

            return await query.FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task RemoveWithImageAsync(int movieId)
        {
            var movie = await _db.Movies
                .Include(m => m.Image)
                .FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie == null)
            {
                throw new MovieByIdNotFoundException(movieId);
            }
            _db.Movies.Remove(movie);
            if (movie.Image != null)
            {
                _db.Images.Remove(movie.Image);
                _imageUploadService.Delete(movie.Image.ImagePath);
            }
            await _db.SaveChangesAsync();
        }
    }
}
