using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Models.ViewModels
{
    public class LoginVM
    {
        [EmailAddress, Required(ErrorMessage = "Email address is required.")]
        [MinLength(1, ErrorMessage = "Invalid email")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Password is required."), DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Invalid password")]
        public string Password { get; set; } = "";
    }
}
