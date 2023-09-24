using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Models.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(32, ErrorMessage = "First name can't be more than 32 character"),
            MinLength(3, ErrorMessage = "First name can't be less than 3 characters")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(32, ErrorMessage = "Last name can't be more than 32 character"),
            MinLength(3, ErrorMessage = "Last name can't be less than 3 characters")]
        public string LastName { get; set; } = "";

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(32, ErrorMessage = "User name can't be more than 32 character"),
            MinLength(4, ErrorMessage = "User name name can't be less than 3 characters")]
        public string UserName { get; set; } = "";

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "This field is required")]
        [Phone]
        public string PhoneNumber { get; set; } = "";

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(32), MinLength(2)]
        public string Country { get; set; } = "";

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(32), MinLength(2)]
        public string State { get; set; } = "";

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(32), MinLength(2)]
        public string City { get; set; } = "";

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(32), MinLength(2)]
        public string Street { get; set; } = "";

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(32), MinLength(2)]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; } = "";

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
            ErrorMessage = "Password must have at least 1 Uppercase, 1 Lowercase, 1 number, 1 non alphanumeric and at least 6 characters")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "This field is required")]
        [Compare(nameof(Password), ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; } = "";
    }
}
