namespace MovieLibrary.Models.ViewModels
{
    public record UserVM
    {
        public string Id { get; init; }
        public string Email { get; init; }
        public string FullName { get; init; }
        public string UserName { get; init; }
        public string PhoneNumber { get; init; }
    }
}
