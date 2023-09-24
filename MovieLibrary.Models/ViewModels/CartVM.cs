using MovieLibrary.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieLibrary.Models.ViewModels
{
    public class CartVM
    {
        public Cart Cart { get; set; }
        public decimal Total { get; set; }
    }
}
