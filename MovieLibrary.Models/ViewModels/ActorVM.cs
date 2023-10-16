using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Models.Models;

namespace MovieLibrary.Models.ViewModels
{
    public record ActorVM
    {
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [DisplayName("Имя")]
        public string FullName { get; init; } = "";

        [DisplayName("Биография")]
        public string? Bio { get; init; } = "";
        public Image Image { get; init; } = new Image();
    }

}
