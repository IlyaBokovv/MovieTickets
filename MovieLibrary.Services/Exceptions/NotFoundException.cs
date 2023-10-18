using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Services.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message, int id)
            : base(message)
        {
            Id = id;
        }
        public int StatusCode => (int)HttpStatusCode.NotFound;
        public int Id { get; init; }
    }

}
