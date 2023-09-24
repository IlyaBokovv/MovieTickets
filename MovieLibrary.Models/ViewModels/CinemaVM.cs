using MovieLibrary.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieLibrary.Models.ViewModels
{
    public class CinemaVM
    {
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; } = "";

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; } = "";
        public Image Image { get; set; } = new Image();
    }
}
