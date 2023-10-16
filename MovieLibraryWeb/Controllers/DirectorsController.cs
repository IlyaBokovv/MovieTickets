using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models.Models;
using MovieLibrary.Models.ViewModels;
using MovieLibrary.Services.Exceptions;
using MovieLibrary.Services.Interfaces;

namespace MovieLibraryWeb.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly IDirectorService _directorService;

        public DirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;
        }
        public async Task<IActionResult> Index()
        {
            var director = await _directorService.GetAllAsync(trackChanges: false, d => d.Image);
            return View(director);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var director = await _directorService.GetByIdAsync(id, trackChanges: false, d => d.Image);
            if (director is null)
            {
                throw new DirectorByIdNotFoundException(id);
            }
            return View(director);
        }

        public IActionResult Create()
        {
            return View(new DirectorVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DirectorVM directorVM)
        {
            var director = new Director()
            {
                FullName = directorVM.FullName,
                Bio = directorVM.Bio,
                Image = new Image() { ImageFile = directorVM.Image.ImageFile }
            };
            if (!ModelState.IsValid)
            {
                return View(directorVM);
            }
            await _directorService.AddDirectorWithImageUplodaing(director);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var director = await _directorService.GetByIdAsync(id, trackChanges: false, d => d.Image);
            if (director is null)
            {
                throw new DirectorByIdNotFoundException(id);
            }
            return View(director);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Director director)
        {
            if (!ModelState.IsValid)
            {
                return View(director);
            }

            await _directorService.UpdateDirectorWithImageAsync(director);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var director = await _directorService.GetByIdAsync(id, trackChanges: false, d => d.Image);
            if (director is null)
            {
                throw new DirectorByIdNotFoundException(id);
            }
            return View(director);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var director = await _directorService.GetByIdAsync(id, trackChanges: false, d => d.Image);
            if (director is null)
            {
                throw new DirectorByIdNotFoundException(id);
            }
            await _directorService.DeleteAsyncWithImage(director);
            return RedirectToAction(nameof(Index));
        }
    }
}
