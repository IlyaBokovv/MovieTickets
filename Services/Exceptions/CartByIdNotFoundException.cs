using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Services.Exceptions
{
    public sealed class CartByIdNotFoundException : NotFoundException
    {
        public CartByIdNotFoundException(int id)
            : base("Корзина с данным id не найдена", id)
        {
        }
    }
}
