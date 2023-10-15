using MovieLibrary.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieLibrary.Models.ViewModels
{
    public class CinemaVM
    {
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [DisplayName("Название")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [DisplayName("Описание")]
        public string? Description { get; set; } = "";
        public Image Image { get; set; } = new Image();
    }
}
