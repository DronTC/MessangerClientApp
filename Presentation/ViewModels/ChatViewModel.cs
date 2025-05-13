using MessangerClientApp.Models;
using MessangerClientApp.Core.Commands;
using System.Windows.Input;

namespace MessangerClientApp.ViewModels
{
    public class ChatViewModel: BaseViewModel
    {
        private string _textBoxValue;

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
        private Chat _chat;
        public Chat Chat
        {
            get => _chat;
            set
            {
                _chat = value;
                OnPropertyChanged(nameof(Chat.Messages));
            }
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
        public ChatViewModel()
        {
            Chat = new Chat();
            SendMessageCommand = new RelayCommand(ExecuteSendMessageCommand, CanSendMessageCommand);
        }
    }
}
