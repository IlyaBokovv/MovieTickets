using MovieLibrary.Models.Models;

namespace MovieLibrary.Models.ViewModels
{
    public class DetailedUserVM : UserVM
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        public Cart? Cart { get; set; }
        public decimal MoneyPaied { get; set; }
        public string Country { get; set; } = "";
        public string State { get; set; } = "";
        public string City { get; set; } = "";
        public string Street { get; set; } = "";
        public string ZipCode { get; set; } = "";
        public IEnumerable<string> Roles { get; set; } = new List<string>();
    }
}
