using MessangerClientApp.Core.Interfaces;
using MessangerClientApp.Core.Commands;
using MessangerClientApp.Models;
using System.Windows;
using System.Windows.Input;
using MessangerClientApp.Infrastructure.Repositories;
using MessangerClientApp.Infrastructure.Api.DTOs;
using MessangerClientApp.Infrastructure;
using MessangerClientApp.Infrastructure.Api.Clients;
using Microsoft.Extensions.Logging;
namespace MessangerClientApp.ViewModels
{
    public class RegViewModel: BaseViewModel
    {
        private string _loginValue;
        private string _emailValue;
        private string _passwordValue;
        private string _confPasswordValue;
        private string _errorMessage;
        private User _user;
        private INavigationService _navService;

        private readonly IUserApiClient _apiClient;
        private readonly ILogger<AuthViewModel> _logger;

        public RegViewModel(INavigationService navService, IUserApiClient apiClient,
        ILogger<AuthViewModel> logger)
        {
            User = new User();
            _apiClient = apiClient;
            _logger = logger;
            _navService = navService;

            RegCommand = new RelayCommand(ExecuteRegCommandAsync);
            SwitchPageCommand = new RelayCommand(ExecuteSwitchPageCommand);
        }

        public ICommand RegCommand { get; private set; }
        public ICommand SwitchPageCommand { get; private set; }
        private async void ExecuteRegCommandAsync(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(LoginValue) && !string.IsNullOrWhiteSpace(PasswordValue))
            {
                try
                {
                    ErrorMessage = string.Empty;

                    var createUserDto = new CreateUserDTO
                    {
                        Login = LoginValue,
                        Email = EmailValue,
                        Password = PasswordValue,
                    };

                    var registeredUser = await _apiClient.RegisterAsync(createUserDto);

                    _logger.LogInformation($"User {registeredUser.Login} registered");

                    _navService.NavigateTo("ChatPage", "ChatFrame");
                    _navService.NavigateTo("ChatListPage", "MainFrame");
                    _navService.ClearFrame("FullScreenFrame");
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                    _logger.LogError(ex, "Registration error");
                }
            }
            else
                MessageBox.Show("Необходимо заполнить все поля");
        }

        private void ExecuteSwitchPageCommand(object parameter)
        {
            _navService.NavigateTo("AuthPage", "FullScreenFrame");
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
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }
    }
}
