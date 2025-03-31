using MessangerClientApp.Core.Interfaces;
using MessangerClientApp.Core.Commands;
using MessangerClientApp.Models;
using System.Windows;
using System.Windows.Input;

namespace MessangerClientApp.ViewModels
{
    public class AuthViewModel: BaseViewModel
    {
        private string _loginValue;
        private string _passwordValue;
        private UserModel _user;
        private readonly INavigationService _navService;
        public ICommand AuthorizationCommand { get; private set; }
        public ICommand SwitchPageCommand { get; private set; }
        private void ExecuteAuthorizationCommand(object parameter)
        {
            var password = PasswordValue;
            if (!string.IsNullOrWhiteSpace(LoginValue) && !string.IsNullOrWhiteSpace(PasswordValue))
            {
                if (User.Authorization(LoginValue, PasswordValue))
                    _navService.NavigateTo("ChatPage", "ChatFrame");
            }
            else
                MessageBox.Show("Необходимо заполнить все поля");
        }
        private void ExecuteSwitchPageCommand(object parameter)
        {
            _navService.NavigateTo("RegPage", "MainFrame");
        }

        public AuthViewModel(INavigationService navService)
        {
            User = new UserModel();
            _navService = navService;

            AuthorizationCommand = new RelayCommand(ExecuteAuthorizationCommand);
            SwitchPageCommand = new RelayCommand(ExecuteSwitchPageCommand);
        }

        public string LoginValue
        {
            get => _loginValue;
            set
            {
                if (_loginValue != value)
                {
                    _loginValue = value;
                    OnPropertyChanged(nameof(LoginValue));
                }
            }
        }
        public string PasswordValue
        {
            get => _passwordValue;
            set
            {
                if (_passwordValue != value)
                {
                    _passwordValue = value;
                    OnPropertyChanged(nameof(PasswordValue));
                }
            }
        }
        public UserModel User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
    }
}
