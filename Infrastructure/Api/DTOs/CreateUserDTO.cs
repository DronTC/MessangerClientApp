using MessangerClientApp.Infrastructure.Api.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MessangerClientApp.Infrastructure.Api.DTOs
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "Логин обязателен")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Логин должен быть от 3 до 20 символов")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 до 100 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный формат email")]
        public string Email { get; set; }
    }
}