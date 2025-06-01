using MessangerClientApp.Infrastructure.Api.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MessangerClientApp.Infrastructure.Api.DTOs
{
    public class CreateUserDTO
    {
        [MaxLength(50)]
        public required string Login { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [MinLength(8)]
        public required string Password { get; set; }

    }
}