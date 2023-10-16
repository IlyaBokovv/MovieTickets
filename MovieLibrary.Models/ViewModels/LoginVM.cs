using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Models.ViewModels
{
    public record LoginVM
    {
        [EmailAddress, Required(ErrorMessage = "Email обязателен для заполнения")]
        [MinLength(1, ErrorMessage = "Неверный email")]
        public string Email { get; init; } = "";

        [Required(ErrorMessage = "Пароль обязателен для заполнения"), DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Неверный пароль")]
        public string Password { get; init; } = "";
    }
}
