using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Services.Exceptions
{
    public sealed class CollectionByIdsBadRequestException : InvalidOperationException
    {
        public CollectionByIdsBadRequestException()
            : base("Collection count mismatch comparing to ids.")
        {
        }
    }
}
