using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Services.Exceptions
{
    public sealed class OrderByIdNotFoundException : NotFoundException
    {
        public OrderByIdNotFoundException(int id)
            : base("Заказ с данным id не найден", id)
        {
        }
    }
}
