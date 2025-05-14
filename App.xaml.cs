using MessangerClientApp.Core.Interfaces;
using MessangerClientApp.Core.Services;
using MessangerClientApp.Infrastructure;
using MessangerClientApp.Infrastructure.Api;
using MessangerClientApp.Infrastructure.Api.Clients;
using MessangerClientApp.Infrastructure.Repositories;
using MessangerClientApp.Presentation.View.Pages;
using MessangerClientApp.Presentation.ViewModels;
using MessangerClientApp.View.Pages;
using MessangerClientApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Windows;

namespace MessangerClientApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ConfigureServices();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            var navigationService = _serviceProvider.GetRequiredService<INavigationService>();
            navigationService.NavigateTo("AuthPage", "FullScreenFrame");
        }
        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<MainWindow>();

            services.AddSingleton<IServiceProvider>(provider => provider);
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddHttpClient<IUserApiClient, UserApiClient>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5233");
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            });
            services.AddTransient<UserService>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<AuthViewModel>();
            services.AddTransient<RegViewModel>();
            services.AddTransient<ChatViewModel>();
            services.AddTransient<ChatListViewModel>();

            services.AddTransient<AuthPage>();
            services.AddTransient<RegPage>();
            services.AddTransient<ChatPage>();
            services.AddTransient<ChatListPage>();

            _serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            (_serviceProvider as IDisposable)?.Dispose();
            base.OnExit(e);
        }
    }

}
