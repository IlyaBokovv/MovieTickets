using MovieLibrary.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieLibrary.Models.ViewModels
{
    public record CinemaVM
    {
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [DisplayName("Название")]
        public string Name { get; init; } = "";

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [DisplayName("Описание")]
        public string? Description { get; init; } = "";
        public Image Image { get; init; } = new Image();
    }
}
