using System.Collections.ObjectModel;

namespace MessangerClientApp.Models
{
    public class Chat
    {
        public ObservableCollection<Message> Messages { get; private set; }

        public Chat() 
        {
            Messages = new ObservableCollection<Message>();
        }

        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }
    }
}
