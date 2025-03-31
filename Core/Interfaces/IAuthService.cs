using System;
using System.Threading.Tasks;

namespace MessangerClientApp.Core.Interfaces
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string loginOrEmail, string password);
        Task<bool> RegisterAsynk(string login, string email, string password);
        //Task LogoutAsynk();
        //bool IsAuthenticated { get; }
        //string GetCurrentUserId();
    }
}
