using MovieLibrary.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieLibrary.Models.ViewModels
{
    public record DirectorVM
    {
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [DisplayName("Имя")]
        public string FullName { get; init; } = "";

        [DisplayName("Биография")]
        public string? Bio { get; init; } = "";
        public Image Image { get; init; } = new Image();
    }
}
