using MovieLibrary.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieLibrary.Models.ViewModels
{
    public class DirectorVM
    {
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [DisplayName("Имя")]
        public string FullName { get; set; } = "";

        [DisplayName("Биография")]
        public string? Bio { get; set; } = "";
        public Image Image { get; set; } = new Image();
    }
}
