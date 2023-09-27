using MovieLibrary.Models.Enums;
using MovieLibrary.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Models.ViewModels
{
    public class MovieVM
    {
        public int Id { get; set; }
        public Image Image { get; set; } = new Image();

        [Required(ErrorMessage = "Название обязательно для заполнения")]
        [Display(Name = "Название фильма")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Цена обязательна для заполнения")]
        [Display(Name = "Цена в ₽")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Описание обязательно для заполнения")]
        [Display(Name = "Description")]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Время начала показа обязательно для заполнения")]
        [Display(Name = "Время начала показа")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Дата окончания показа обязательна для заполнения ")]
        [Display(Name = "Дата окончания показа")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Жанр обязателен для заполнения")]
        [Display(Name = "Жанр")]
        public MovieCategory MovieCategory { get; set; }

        [Required(ErrorMessage = "Режиссер обязателен для заполнения")]
        [Display(Name = "Режиссер")]
        public int DirectorId { get; set; }

        [Required(ErrorMessage = "Кинотеарт обязателен для заполнения")]
        [Display(Name = "Кинотеатр")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "В фильме должен быть как минимум 1 актер")]
        [Display(Name = "Актеры")]
        public IEnumerable<int> ActorIds { get; set; } = new List<int>();
    }
}
