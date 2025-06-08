using MessangerClientApp.Core.Commands;
using System.Windows;
using System.Windows.Input;
using MessangerClientApp.Infrastructure.Api.DTOs;
using MessangerClientApp.Infrastructure.Api.Clients;
using Serilog;
using MessangerClientApp.Infrastructure.Services;

namespace MessangerClientApp.Presentation.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        private string? _loginValue;
        private string? _passwordValue;
        private bool _isPasswordVisible;
        private string _passwordVisibleValue;
        private readonly IUserApiClient _apiClient;
        private readonly INavigationService _navService;
        public ICommand AuthorizationCommand { get; private set; }
        public ICommand SwitchPageCommand { get; private set; }
        public ICommand TogglePasswordCommand { get; }
        public AuthViewModel(INavigationService navService, IUserApiClient apiClient)
        {
            _navService = navService;
            _apiClient = apiClient;

            IsPasswordVisible = false;
            PasswordVisibleValue = "Hidden";

            AuthorizationCommand = new RelayCommand(ExecuteAuthAsyncCommand);
            SwitchPageCommand = new RelayCommand(ExecuteSwitchPageCommand);
            TogglePasswordCommand = new RelayCommand(ExecuteTogglePasswordCommand);
        }
        private async void ExecuteAuthAsyncCommand(object parameter)
        {
            //_navService.NavigateTo("ChatPage", "ChatFrame");
            //_navService.NavigateTo("ChatListPage", "MainFrame");
            _navService.ClearFrame("FullScreenFrame");
            _navService.NavigateTo("HomePage", "MainFrame");
            //var password = PasswordValue;
            //if (!string.IsNullOrWhiteSpace(LoginValue) && !string.IsNullOrWhiteSpace(PasswordValue))
            //{
            //    try
            //    {
            //        var loginDTO = new LoginUserDTO
            //        {
            //            Login = LoginValue,
            //            Password = PasswordValue
            //        };

            //        var authResponse = await _apiClient.LoginAsync(loginDTO);

            //        Log.Information($"User {LoginValue} logged in");

            //        _navService.NavigateTo("ChatPage", "ChatFrame");
            //        _navService.NavigateTo("ChatListPage", "MainFrame");
            //        _navService.ClearFrame("FullScreenFrame");
            //    }
            //    catch (Exception ex)
            //    {
            //        Log.Error(ex, "Login error");
            //        MessageBox.Show("Отсутствует доступ к серверу");
            //    }
            //}
            //else
            //    MessageBox.Show("Необходимо заполнить все поля");
        }
        private void ExecuteSwitchPageCommand(object parameter)
        {
            _navService.NavigateTo("RegPage", "FullScreenFrame");
        }
        private void ExecuteTogglePasswordCommand(object parameter)
        {
            if (!IsPasswordVisible)
                PasswordVisibleValue = "Visible";
            else
                PasswordVisibleValue = "Hidden";
            IsPasswordVisible = !IsPasswordVisible;
        }

        public string? LoginValue
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
        public string? PasswordValue
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
        public bool IsPasswordVisible
        {
            get => _isPasswordVisible;
            set
            {
                _isPasswordVisible = value;
                OnPropertyChanged();
            }
        }
        public string PasswordVisibleValue
        {
            get => _passwordVisibleValue;
            set
            {
                _passwordVisibleValue = value;
                OnPropertyChanged();
            }
        }
    }
}
