using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Services.Exceptions
{
    public sealed class ActorByIdNotFoundException : NotFoundException
    {
        public ActorByIdNotFoundException(int id)
            : base("Актер с данным id не найден", id)
        {
        }
    }
}
