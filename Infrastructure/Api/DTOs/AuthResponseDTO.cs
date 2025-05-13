using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerClientApp.Infrastructure.Api.DTOs
{
    public class AuthResponseDTO
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
