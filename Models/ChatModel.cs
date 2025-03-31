using System.Collections.ObjectModel;

namespace MessangerClientApp.Models
{
    public class ChatModel
    {
        public ObservableCollection<MessageModel> Messages { get; private set; }

        public ChatModel() 
        {
            Messages = new ObservableCollection<MessageModel>();
        }

        public void AddMessage(MessageModel message)
        {
            Messages.Add(message);
        }
    }
}
