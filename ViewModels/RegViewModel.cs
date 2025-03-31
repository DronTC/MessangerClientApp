using MessangerClientApp.Core.Interfaces;
using MessangerClientApp.Core.Commands;
using MessangerClientApp.Models;
using System.Windows;
using System.Windows.Input;

namespace MessangerClientApp.ViewModels
{
    public class RegViewModel: BaseViewModel
    {
        private string _loginValue;
        private string _emailValue;
        private string _passwordValue;
        private string _confPasswordValue;
        private UserModel _user;
        private INavigationService _navService;

        public ICommand RegistrationCommand { get; private set; }
        public ICommand SwitchPageCommand { get; private set; }
        private void ExecuteRegistrationCommand(object parameter)
        {
            var password = PasswordValue;
            if (!string.IsNullOrWhiteSpace(LoginValue) && !string.IsNullOrWhiteSpace(PasswordValue))
            {
                if (User.Authorization(LoginValue, PasswordValue))
                    MessageBox.Show("Работает");
            }
            else
                MessageBox.Show("Необходимо заполнить все поля");
        }
        private void ExecuteSwitchPageCommand(object parameter)
        {
            _navService.NavigateTo("AuthPage", "MainFrame");
        }
        public RegViewModel(INavigationService navService)
        {
            User = new UserModel();
            _navService = navService;

            RegistrationCommand = new RelayCommand(ExecuteRegistrationCommand);
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
        public string EmailValue
        {
            get => _emailValue;
            set
            {
                if (_emailValue != value)
                {
                    _emailValue = value;
                    OnPropertyChanged(nameof(EmailValue));
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
        public string ConfPasswordValue
        {
            get => _confPasswordValue;
            set
            {
                if (_confPasswordValue != value)
                {
                    _confPasswordValue = value;
                    OnPropertyChanged(nameof(ConfPasswordValue));
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
