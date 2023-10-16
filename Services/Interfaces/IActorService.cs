using MovieLibrary.DataAccess.Repository.IRepository;
using MovieLibrary.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IActorService : IRepositoryBase<Actor>
    {
        public Task<Actor> AddActorWithImage(Actor actor);
        public Task<Actor> UpdateActorWithImageAsync(Actor actor);
        public Task DeleteAsyncWithImage(Actor actor);
    }
}
