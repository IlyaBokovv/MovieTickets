using Microsoft.EntityFrameworkCore;
using MovieLibrary.DataAccess;
using MovieLibrary.DataAccess.Repository;
using MovieLibrary.DataAccess.Repository.IRepository;
using MovieLibrary.Models.Models;
using MovieLibrary.Models.Static;
using MovieLibrary.Services.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Services.Services
{
    public class ActorService : RepositoryBase<Actor>, IActorService
    {
        private readonly ApplicationDbContext _db;
        private readonly IImageUploadService _imageUploadService;

        public ActorService(ApplicationDbContext db, IImageUploadService imageUploadService) : base(db)
        {
            _db = db;
            _imageUploadService = imageUploadService;
        }
        public async Task<Actor> UpdateActorWithImageAsync(Actor actor)
        {
            var oldImage = await _db.Actors.Include(a => a.Image)
                .Where(i => i.Id == actor.Id)
                .Select(a => a.Image)
                .FirstOrDefaultAsync();
            if (actor.Image!.ImageFile is not null)
            {
                _imageUploadService.Delete(oldImage.ImagePath);
                actor.Image.ImagePath = await _imageUploadService.UploadAsync(actor.Image, nameof(Actor) + actor.FullName!,
                    ImageType.Actor);
                _db.Actors.Attach(actor);
                _db.Images.Remove(oldImage);
                await _db.Images.AddAsync(actor.Image);
                await _db.SaveChangesAsync();
                return actor;
            }
            actor.ImageId = oldImage.Id;
            await UpdateAsync(actor);
            return actor;
        }
        public async Task<Actor> AddActorWithImage(Actor actor)
        {
            if (actor.Image.ImageFile is not null)
            {
                var imagePath = await _imageUploadService.UploadAsync(actor.Image, nameof(Actor) + actor.FullName!, ImageType.Actor);
                actor.Image.ImagePath = imagePath;
            }

            await _db.Actors.AddAsync(actor);
            await _db.SaveChangesAsync();
            return actor;
        }

        public async Task DeleteAsyncWithImage(Actor actor)
        {
            _db.Actors.Remove(actor);
            if (actor.Image != null)
            {
                _imageUploadService.Delete(actor.Image.ImagePath);
                _db.Images.Remove(actor.Image);
            }
            await _db.SaveChangesAsync();
        }
    }
}
