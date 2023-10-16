using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Models.ViewModels
{
    public record RegisterVM
    {
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [MaxLength(32, ErrorMessage = "Имя не может быть больше 32 символов"),
            MinLength(3, ErrorMessage = "Имя не может быть короче 3 символов")]
        public string FirstName { get; init; } = "";

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [MaxLength(32, ErrorMessage = "Фамилия не может быть больше 32 символов"),
            MinLength(3, ErrorMessage = "Фамилия не может быть короче 3 символов")]
        public string LastName { get; init; } = "";

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [MaxLength(32, ErrorMessage = "Логин не может быть больше 32 символов"),
            MinLength(4, ErrorMessage = "Логин не может быть меньше 4 символов")]
        public string UserName { get; init; } = "";

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [EmailAddress]
        public string Email { get; init; } = "";

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Phone]
        public string PhoneNumber { get; init; } = "";

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [MaxLength(32, ErrorMessage = "Это поле должно быть короче 32 символов"),
            MinLength(2, ErrorMessage = "Это поле должно быть больше 2 символов")]
        public string Country { get; init; } = "";

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [MaxLength(32, ErrorMessage = "Это поле должно быть короче 32 символов"),
            MinLength(2, ErrorMessage ="Это поле должно быть больше 2 символов")]
        public string City { get; init; } = "";

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [DataType(DataType.Password)]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
            ErrorMessage = "Пароль должен содержать как минимум 1 заглавную букву, 1 строчную букву, 1 цифру, 1 не буквенно-цифровой символ и быть длиной не менее 6 символов.")]
        public string Password { get; init; } = "";

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; init; } = "";
    }
}
