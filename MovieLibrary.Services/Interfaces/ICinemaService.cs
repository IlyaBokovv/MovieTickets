using MovieLibrary.DataAccess.Repository.IRepository;
using MovieLibrary.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Services.Interfaces
{
    public interface ICinemaService : IRepositoryBase<Cinema>
    {
        public Task<Cinema> UpdateWithImageAsync(Cinema cinema);
        public Task<Cinema> AddWithImageUplodaing(Cinema cinema);
        public Task DeleteAsyncWithImage(Cinema cinema);
    }
}
