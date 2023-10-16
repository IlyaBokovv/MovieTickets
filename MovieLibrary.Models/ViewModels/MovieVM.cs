using MovieLibrary.Models.Enums;
using MovieLibrary.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Models.ViewModels
{
    public record MovieVM
    {
        public int Id { get; init; }
        public Image Image { get; init; } = new Image();

        [Required(ErrorMessage = "Название обязательно для заполнения")]
        [Display(Name = "Название фильма")]
        public string Name { get; init; } = "";

        [Required(ErrorMessage = "Цена обязательна для заполнения")]
        [Range(100, int.MaxValue, ErrorMessage ="Цена должна начинаться от 100")]
        [Display(Name = "Цена в ₽")]
        public decimal Price { get; init; }

        [Required(ErrorMessage = "Описание обязательно для заполнения")]
        [Display(Name = "Description")]
        public string Description { get; init; } = "";

        [Required(ErrorMessage = "Время начала показа обязательно для заполнения")]
        [Display(Name = "Время начала показа")]
        public DateTime StartDate { get; init; } = DateTime.Now;

        [Required(ErrorMessage = "Дата окончания показа обязательна для заполнения ")]
        [Display(Name = "Дата окончания показа")]
        public DateTime EndDate { get; init; } = DateTime.Now.AddDays(7);

        [Required(ErrorMessage = "Жанр обязателен для заполнения")]
        [Display(Name = "Жанр")]
        public MovieCategory MovieCategory { get; init; }

        [Required(ErrorMessage = "Режиссер обязателен для заполнения")]
        [Display(Name = "Режиссер")]
        public int DirectorId { get; init; }

        [Required(ErrorMessage = "Кинотеарт обязателен для заполнения")]
        [Display(Name = "Студия")]
        public int CinemaId { get; init; }

        [Required(ErrorMessage = "В фильме должен быть как минимум 1 актер")]
        [Display(Name = "Актеры")]
        public IEnumerable<int> ActorIds { get; init; } = new List<int>();
    }
}
