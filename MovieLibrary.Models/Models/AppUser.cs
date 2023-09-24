using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Models.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public int UserAddressId { get; set; }

        public UserAddress UserAddress { get; set; } = new UserAddress();
        public List<Order> Orders { get; set; } = new List<Order>();
        public Cart? Cart { get; set; }
        public string GetFullName() => FirstName + (string.IsNullOrEmpty(LastName) ? "" : " " + LastName);
    }
}
