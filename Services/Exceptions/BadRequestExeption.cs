using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Services.Exceptions
{
    public abstract class BadRequestExeption : Exception
    {
        protected BadRequestExeption(string message, string id)
            : base(message)
        {
            Id = id;
        }
        public int StatusCode => (int)HttpStatusCode.NotFound;
        public string Id { get; init; }
    }

}
