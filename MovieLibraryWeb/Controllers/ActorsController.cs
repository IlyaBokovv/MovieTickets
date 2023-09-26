using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models.Models;
using MovieLibrary.Models.Static;
using MovieLibrary.Models.ViewModels;
using Services.Interfaces;
using System.Data;

namespace MovieLibraryWeb.Controllers
{
    [Authorize(Roles = UserRolesValues.Admin)]
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ActorsController(IActorService actorService, IWebHostEnvironment hostEnvironment)
        {
            this._actorService = actorService;
            this._hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var actors = await _actorService.GetAllAsync(trackChanges: false, a => a.Image);
            return View(actors);
        }

        public IActionResult Create()
        {
            return View(new ActorVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActorVM actorVM)
        {
            var actor = new Actor()
            {
                FullName = actorVM.FullName,
                Bio = actorVM.Bio,
                Image = new Image() { ImageFile = actorVM.Image.ImageFile }
            };
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _actorService.AddActorWithImageUplodaing(actor);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var actor = await _actorService.GetByIdAsync(id, trackChanges: false, a => a.Image);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _actorService.GetByIdAsync(id, trackChanges: false, a => a.Image);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _actorService.UpdateActorWithImageAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _actorService.GetByIdAsync(id, trackChanges: false, a => a.Image);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actor = await _actorService.GetByIdAsync(id, trackChanges: false, a => a.Image);
            if (actor == null)
            {
                return View("NotFound");
            }
            await _actorService.DeleteAsyncWithImage(actor);
            return RedirectToAction(nameof(Index));
        }
    }
}
