using MovieLibrary.DataAccess.Repository.IRepository;
using MovieLibrary.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Services.Interfaces
{
    public interface IDirectorService : IRepositoryBase<Director>
    {
        public Task<Director> AddDirectorWithImageUplodaing(Director director);
        public Task<Director> UpdateDirectorWithImageAsync(Director director);
        public Task DeleteAsyncWithImage(Director director);
    }
}
