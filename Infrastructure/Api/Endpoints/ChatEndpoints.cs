namespace MessangerClientApp.Infrastructure.Api.Endpoints
{
    class ChatEndpoints
    {
        private const string BasePath = "/api/chats";

        public static string GetById(int id) => $"{BasePath}/{id}";
        public static string Create => BasePath;
        public static string Update => BasePath;
        public static string Delete(int id) => $"{BasePath}/{id}";
    }
}
