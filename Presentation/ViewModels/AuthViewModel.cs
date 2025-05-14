using MessangerClientApp.Core.Interfaces;
using MessangerClientApp.Core.Commands;
using MessangerClientApp.Models;
using System.Windows;
using System.Windows.Input;
using MessangerClientApp.Infrastructure.Repositories;
using MessangerClientApp.Infrastructure.Api.DTOs;
using MessangerClientApp.Infrastructure.Api.Clients;
using Microsoft.Extensions.Logging;

namespace MessangerClientApp.ViewModels
{
    public class AuthViewModel: BaseViewModel
    {
        private string _loginValue;
        private string _passwordValue;
        private User _user;
        private string _errorMessage;
        private ILogger _logger;
        private IUserApiClient _apiClient;
        private readonly INavigationService _navService;
        public AuthViewModel(INavigationService navService, IUserApiClient apiClient,
        ILogger<AuthViewModel> logger)
        {
            User = new User();
            _navService = navService;
            _apiClient = apiClient;
            _logger = logger;

            AuthorizationCommand = new RelayCommand(ExecuteAuthAsyncCommand);
            SwitchPageCommand = new RelayCommand(ExecuteSwitchPageCommand);
        }
        public ICommand AuthorizationCommand { get; private set; }
        public ICommand SwitchPageCommand { get; private set; }
        private async void ExecuteAuthAsyncCommand(object parameter)
        {
            _navService.NavigateTo("ChatPage", "ChatFrame");
            _navService.NavigateTo("ChatListPage", "MainFrame");
            _navService.ClearFrame("FullScreenFrame");
            //var password = PasswordValue;
            //if (!string.IsNullOrWhiteSpace(LoginValue) && !string.IsNullOrWhiteSpace(PasswordValue))
            //{
            //    try
            //    {
            //        ErrorMessage = string.Empty;

            //        var loginDto = new LoginUserDTO
            //        {
            //            Login = LoginValue,
            //            Password = PasswordValue
            //        };

            //        var authResponse = await _apiClient.LoginAsync(loginDto);

            //        _logger.LogInformation($"User {LoginValue} logged in");

            //        _navService.NavigateTo("ChatPage", "ChatFrame");
            //        _navService.ClearFrame("FullScreenFrame");
            //    }
            //    catch (Exception ex)
            //    {
            //        ErrorMessage = ex.Message;
            //        _logger.LogError(ex, "Login error");
            //    }
            //}
            //else
            //    MessageBox.Show("Необходимо заполнить все поля");
        }
        private void ExecuteSwitchPageCommand(object parameter)
        {
            _navService.NavigateTo("RegPage", "FullScreenFrame");
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
