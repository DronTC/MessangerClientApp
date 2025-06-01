using MessangerClientApp.Core.Commands;
using System.Windows;
using System.Windows.Input;
using MessangerClientApp.Infrastructure.Api.DTOs;
using MessangerClientApp.Infrastructure.Api.Clients;
using Serilog;
using MessangerClientApp.Infrastructure.Services;

namespace MessangerClientApp.Presentation.ViewModels
{
    public class RegViewModel: BaseViewModel
    {
        private string? _loginValue;
        private string? _emailValue;
        private string? _passwordValue;
        private string? _confPasswordValue;
        private readonly INavigationService _navService;
        private readonly IUserApiClient _apiClient;
        public ICommand RegCommand { get; private set; }
        public ICommand SwitchPageCommand { get; private set; }
        public RegViewModel(INavigationService navService, IUserApiClient apiClient)
        {
            _apiClient = apiClient;
            _navService = navService;

            RegCommand = new RelayCommand(ExecuteRegCommandAsync);
            SwitchPageCommand = new RelayCommand(ExecuteSwitchPageCommand);
        }
        private async void ExecuteRegCommandAsync(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(LoginValue) 
                && !string.IsNullOrWhiteSpace(EmailValue) 
                && !string.IsNullOrWhiteSpace(PasswordValue))
            {
                try
                {
                    var createUserDTO = new CreateUserDTO
                    {
                        Login = LoginValue,
                        Email = EmailValue,
                        Password = PasswordValue,
                    };

                    var registeredUser = await _apiClient.RegisterAsync(createUserDTO);

                    Log.Information($"User {registeredUser.Login} registered");

                    _navService.NavigateTo("ChatPage", "ChatFrame");
                    _navService.NavigateTo("ChatListPage", "MainFrame");
                    _navService.ClearFrame("FullScreenFrame");
                    return;
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Registration error");
                    MessageBox.Show("Отсутствует доступ к серверу");
                }
            }
            else
                MessageBox.Show("Необходимо заполнить все поля");
        }

        private void ExecuteSwitchPageCommand(object parameter)
        {
            _navService.NavigateTo("AuthPage", "FullScreenFrame");
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
        public string? EmailValue
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
        public string? ConfPasswordValue
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
    }
}