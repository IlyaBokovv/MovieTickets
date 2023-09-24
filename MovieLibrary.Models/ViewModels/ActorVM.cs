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
    public class ActorVM
    {
        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; } = "";

        [Required]
        [DisplayName("Bio")]
        public string Bio { get; set; } = "";
        public Image Image { get; set; } = new Image();
    }

}
