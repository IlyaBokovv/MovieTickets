using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models.Static;
using MovieLibrary.Models.ViewModels;
using MovieLibrary.Services.Interfaces;
using Services.Interfaces;
using System.Data;
using MovieLibrary.Models.Models;
using System.Diagnostics;
using System.Net;

namespace MovieLibraryWeb.Controllers
{
    [Authorize(Roles = UserRolesValues.Admin)]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICinemaService _cinemaService;
        private readonly IActorService _actorService;
        private readonly IDirectorService _producerService;

        public MoviesController(IMovieService movieService, ICinemaService cinemaService, IActorService actorService, IDirectorService producerService)
        {
            _movieService = movieService;
            _cinemaService = cinemaService;
            _actorService = actorService;
            _producerService = producerService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            throw new Exception("HAHAHAHA");
            var movies = await _movieService.GetAllAsync(trackChanges: false, n => n.Cinema, m => m.Image);
            return View(movies);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService
                .GetByIdWithInclusionAsync(id);
            if (movie != null)
            {
                return View(movie);
            }
            return View("NotFound");
        }

        public async Task<IActionResult> Create()
        {
            var actors = await _actorService.GetAllAsync();
            var producers = await _producerService.GetAllAsync();
            var cinemas = await _cinemaService.GetAllAsync();
            ViewBag.Actors = new SelectList(actors, "Id", "FullName");
            ViewBag.Producers = new SelectList(producers, "Id", "FullName");
            ViewBag.Cinemas = new SelectList(cinemas, "Id", "Name");
            return View(new MovieVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieVM movieVm)
        {
            var actors = await _actorService.GetAllAsync();
            var producers = await _producerService.GetAllAsync();
            var cinemas = await _cinemaService.GetAllAsync();
            ViewBag.Actors = new SelectList(actors, "Id", "FullName");
            ViewBag.Producers = new SelectList(producers, "Id", "FullName");
            ViewBag.Cinemas = new SelectList(cinemas, "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View(movieVm);
            }

            var movie = await _movieService.AddMovieVMAsync(movieVm);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieService
                .GetByIdWithInclusionAsync(id);
            if (movie == null)
            {
                return View("NotFound");
            }

            var actors = await _actorService.GetAllAsync();
            var producers = await _producerService.GetAllAsync();
            var cinemas = await _cinemaService.GetAllAsync();

            var movieVm = new MovieVM()
            {
                Id = movie!.Id,
                Image = movie.Image,
                Name = movie.Name,
                Price = movie.Price,
                Description = movie.Description,
                StartDate = movie.StratDate,
                EndDate = movie.EndDate,
                MovieCategory = movie.MovieCategory,
                DirectorId = movie.DirectorId,
                CinemaId = movie.CinemaId,
                ActorIds = movie.ActorsMovies!.Select(am => am.ActorId)
            };
            ViewBag.Actors = new SelectList(actors, "Id", "FullName");
            ViewBag.Producers = new SelectList(producers, "Id", "FullName");
            ViewBag.Cinemas = new SelectList(cinemas, "Id", "Name");

            return View(movieVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MovieVM movieVm)
        {
            var actors = await _actorService.GetAllAsync();
            var producers = await _producerService.GetAllAsync();
            var cinemas = await _cinemaService.GetAllAsync();
            ViewBag.Actors = new SelectList(actors, "Id", "FullName");
            ViewBag.Producers = new SelectList(producers, "Id", "FullName");
            ViewBag.Cinemas = new SelectList(cinemas, "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View(movieVm);
            }

            var movie = await _movieService.UpdateMovieVMAsync(movieVm);

            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var movies = await _movieService.GetAllAsync(trackChanges: false, n => n.Image);
            if (string.IsNullOrEmpty(searchString))
            {
                return View("Index", movies);
            }
            searchString = searchString.ToLower();
            return View("Index", movies.Where(m => m.Name!.ToLower().Contains(searchString) || m.Description!.ToLower().Contains(searchString)));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieService.GetByIdAsync(id, trackChanges: false, m => m.Image);
            if (movie == null)
            {
                return View("NotFound");
            }
            return View(movie);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _movieService.RemoveWithImageAsync(id);
            }
            catch (InvalidOperationException ex)
            {
                BadRequest(ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
