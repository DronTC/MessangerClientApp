namespace MessangerClientApp.Infrastructure.Api.Endpoints
{
    public static class MessageEndpoints
    {
        private const string BasePath = "/api/messages";

        public static string GetById(int id) => $"{BasePath}/{id}";

        public static string Create => BasePath;

        public static string Update => BasePath;

        public static string Delete(int id) => $"{BasePath}/{id}";

        public static string GetByChatId(int chatId) => $"{BasePath}/chat/{chatId}";

        public static string GetMessageByIdRoute => "GetMessageById";
    }
}
