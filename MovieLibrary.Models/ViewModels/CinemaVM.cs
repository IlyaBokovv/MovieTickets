using MovieLibrary.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieLibrary.Models.ViewModels
{
    public class CinemaVM
    {
        [Required]
        [DisplayName("Название")]
        public string Name { get; set; } = "";

        [Required]
        [DisplayName("Описание")]
        public string? Description { get; set; } = "";
        public Image Image { get; set; } = new Image();
    }
}
