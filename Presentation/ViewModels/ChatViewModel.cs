using MessangerClientApp.Models;
using MessangerClientApp.Core.Commands;
using System.Windows.Input;

namespace MessangerClientApp.Presentation.ViewModels
{
    public class ChatViewModel: BaseViewModel
    {
        private string _chatNameValue;
        private string _textBoxValue;
        private Chat _chat;
        public ChatViewModel()
        {
            Chat = new Chat();
            ChatNameValue = "Chat name";
            SendMessageCommand = new RelayCommand(ExecuteSendMessageCommand, CanSendMessageCommand);
        }
        public ICommand SendMessageCommand{ get; private set; }
        private void ExecuteSendMessageCommand(object parameter)
        {
            var newMessage = new Message("USER", _textBoxValue);
            Chat.AddMessage(newMessage);
        }
        private bool CanSendMessageCommand(object parameter)
        {
            return !string.IsNullOrWhiteSpace(_textBoxValue);
        }

        public string ChatNameValue
        {
            get => _chatNameValue;
            set
            {
                if (_chatNameValue != value)
                {
                    _chatNameValue = value;
                    OnPropertyChanged(nameof(ChatNameValue));
                }
            }
        }
        public string TextBoxValue
        {
            get => _textBoxValue;
            set
            {
                if (_textBoxValue != value)
                {
                    _textBoxValue = value;
                    OnPropertyChanged(nameof(TextBoxValue));
                }
            }
        }
        public Chat Chat
        {
            get => _chat;
            set
            {
                _chat = value;
                OnPropertyChanged(nameof(Chat.Messages));
            }
        }
    }
}
