using MessangerClientApp.Core.Interfaces;

namespace MessangerClientApp.Core.Services
{
    public class AuthService: IAuthService
    {
        public Task<bool> LoginAsync(string loginOrEmail, string password)
        {
            return Task.FromResult(true);
        }

        public Task<bool> RegisterAsynk(string login, string email, string password)
        {
            return Task.FromResult(true);
        }

        //Task LogoutAsynk()
        //{
            
        //}

        //public bool IsAuthenticated()
        //{
        //    return true;
        //}
        //public string GetCurrentUserId()
        //{
        //    return "";
        //}
    }
}
