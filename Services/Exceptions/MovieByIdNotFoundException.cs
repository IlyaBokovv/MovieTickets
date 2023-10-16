using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Services.Exceptions
{
    public sealed class MovieByIdNotFoundException : NotFoundException
    {
        public MovieByIdNotFoundException()
            : base("Пользователь с данным id не найден")
        {
        }
    }
}
