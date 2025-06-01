namespace MessangerClientApp.Infrastructure.Api.Endpoints
{
    class UserEndpoints
    {
        private const string BasePath = "/api/users";

        public static string GetUser(int userId)
        {
            return $"{BasePath}/{userId}";
        }
        public static string GetById(int id) => $"{BasePath}/{id}";
        public static string Register => $"{BasePath}";
        public static string Login => $"{BasePath}/login";
    }
}
