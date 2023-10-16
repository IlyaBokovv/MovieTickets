using MovieLibrary.Models.Models;

namespace MovieLibrary.Models.ViewModels
{
    public record DetailedUserVM : UserVM
    {
        public List<Order> Orders { get; init; } = new List<Order>();
        public Cart? Cart { get; init; }
        public decimal MoneyPaied { get; init; }
        public string Country { get; init; } = "";
        public string State { get; init; } = "";
        public string City { get; init; } = "";
        public string Street { get; init; } = "";
        public string ZipCode { get; init; } = "";
        public IEnumerable<string> Roles { get; init; } = new List<string>();
    }
}
