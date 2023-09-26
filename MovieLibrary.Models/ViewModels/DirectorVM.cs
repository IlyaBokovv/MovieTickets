using MovieLibrary.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieLibrary.Models.ViewModels
{
    public class DirectorVM
    {
        [Required]
        [DisplayName("Имя")]
        public string FullName { get; set; } = "";

        [Required]
        [DisplayName("Bio")]
        public string Bio { get; set; } = "";
        public Image Image { get; set; } = new Image();
    }
}
