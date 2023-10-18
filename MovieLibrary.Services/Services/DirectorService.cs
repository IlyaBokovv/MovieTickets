using Microsoft.EntityFrameworkCore;
using MovieLibrary.Models.Models;
using MovieLibrary.Services.Interfaces;
using MovieLibrary.DataAccess.Repository;
using MovieLibrary.DataAccess;
using MovieLibrary.Models.Static;
using MovieLibrary.Models.ViewModels;
using MovieLibrary.Services.Exceptions;

namespace MovieLibrary.Services.Services
{
    public class DirectorService : RepositoryBase<Director>, IDirectorService
    {
        private readonly ApplicationDbContext _db;
        private readonly IImageUploadService _imageUploadService;

        public DirectorService(ApplicationDbContext db, IImageUploadService imageUploadService)
            : base(db)
        {
            _db = db;
            _imageUploadService = imageUploadService;
        }
        public async Task<Director> UpdateDirectorWithImageAsync(Director director)
        {
            var oldImage = await _db.Cinemas.Include(a => a.Image)
                .Where(i => i.Id == director.Id)
                .Select(a => a.Image)
                .FirstOrDefaultAsync();
            if (director.Image!.ImageFile is not null)
            {
                _imageUploadService.Delete(oldImage.ImagePath);
                director.Image.ImagePath = await _imageUploadService.UploadAsync(director.Image, nameof(Director) + director.FullName!,
                    ImageType.Cinemas);
                _db.Directors.Attach(director);
                _db.Images.Remove(oldImage);
                await _db.Images.AddAsync(director.Image);
                await UpdateAsync(director);
                await _db.SaveChangesAsync();
                return director;
            }
            director.ImageId = oldImage.Id;
            await UpdateAsync(director);
            return director;
        }
        public async Task<Director> AddDirectorWithImageUplodaing(Director director)
        {
            if (director.Image.ImageFile is not null)
            {
                var imagePath = await _imageUploadService.UploadAsync(director.Image, nameof(Director) + director.FullName!, ImageType.Directors);
                director.Image.ImagePath = imagePath;
            }
            await _db.Directors.AddAsync(director);
            await _db.SaveChangesAsync();
            return director;
        }
        public async Task DeleteAsyncWithImage(Director director)
        {
            _db.Directors.Remove(director);
            if (director.Image != null)
            {
                _imageUploadService.Delete(director.Image.ImagePath);
                _db.Images.Remove(director.Image);
            }
            await _db.SaveChangesAsync();
        }
    }
}
