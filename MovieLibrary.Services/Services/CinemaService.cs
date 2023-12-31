﻿using Microsoft.EntityFrameworkCore;
using MovieLibrary.DataAccess;
using MovieLibrary.DataAccess.Repository;
using MovieLibrary.Models.Models;
using MovieLibrary.Models.Static;
using MovieLibrary.Services.Interfaces;

namespace MovieLibrary.Services.Services
{
    public class CinemaService : RepositoryBase<Cinema>, ICinemaService
    {
        private readonly ApplicationDbContext _db;
        private readonly IImageUploadService _imageUploadService;

        public CinemaService(ApplicationDbContext db, IImageUploadService imageUploadService) : base(db)
        {
            _db = db;
            _imageUploadService = imageUploadService;
        }
        public async Task<Cinema> UpdateWithImageAsync(Cinema cinema)
        {
            var oldImage = await _db.Cinemas.Include(a => a.Image)
                .Where(i => i.Id == cinema.Id)
                .Select(a => a.Image)
                .FirstOrDefaultAsync();
            if (cinema.Image!.ImageFile is not null)
            {
                _imageUploadService.Delete(oldImage.ImagePath);
                cinema.Image.ImagePath = await _imageUploadService.UploadAsync(cinema.Image, nameof(Cinema) + cinema.Name!,
                    ImageType.Cinemas);
                _db.Cinemas.Attach(cinema);
                _db.Images.Remove(oldImage);
                await _db.Images.AddAsync(cinema.Image);
                await UpdateAsync(cinema);
                await _db.SaveChangesAsync();
                return cinema;
            }
            cinema.ImageId = oldImage.Id;
            await UpdateAsync(cinema);
            return cinema;
        }
        public async Task<Cinema> AddWithImageUplodaing(Cinema cinema)
        {
            if (cinema.Image.ImageFile is not null)
            {
                var imagePath = await _imageUploadService.UploadAsync(cinema.Image, nameof(Cinema) + cinema.Name!, ImageType.Cinemas);
                cinema.Image.ImagePath = imagePath;
            }
            await _db.Cinemas.AddAsync(cinema);
            await _db.SaveChangesAsync();
            return cinema;
        }
        public async Task DeleteAsyncWithImage(Cinema cinema)
        {
            _db.Cinemas.Remove(cinema);
            if (cinema.Image != null)
            {
                _imageUploadService.Delete(cinema.Image.ImagePath);
                _db.Images.Remove(cinema.Image);
            }
            await _db.SaveChangesAsync();
        }
    }
}
