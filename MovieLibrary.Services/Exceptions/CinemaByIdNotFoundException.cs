﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Services.Exceptions
{
    public sealed class CinemaByIdNotFoundException : NotFoundException
    {
        public CinemaByIdNotFoundException(int id)
            : base("Фильм с данным id не найден", id)
        {
        }
    }
}
