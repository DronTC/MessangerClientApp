namespace MessangerClientApp.Models
{
    public class Message
    {
        public string User { get; set; }
        public string Content { get; set; }
        public string TimeStamp { get; set; }
        public Message(string user, string content)
        {
            User = user;
            Content = content;
            TimeStamp = TimeOnly.FromDateTime(DateTime.Now).ToString("hh:mm");
        }
    }
}
