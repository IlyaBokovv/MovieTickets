using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Services.Exceptions
{
    public sealed class ImageDirectorByIdNotFoundException : NotFoundException
    {
        public ImageDirectorByIdNotFoundException(int id)
            : base("Директория изображения с данным id не найдена", id)
        {
        }
    }
}
