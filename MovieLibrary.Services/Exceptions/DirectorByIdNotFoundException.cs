﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Services.Exceptions
{
    public sealed class DirectorByIdNotFoundException : NotFoundException
    {
        public DirectorByIdNotFoundException(int id)
            : base("Режиссер с данным id не найден", id)
        {
        }
    }
}
