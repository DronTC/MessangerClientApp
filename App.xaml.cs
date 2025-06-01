using MessangerClientApp.Core.Services;
using MessangerClientApp.Infrastructure;
using MessangerClientApp.Infrastructure.Api;
using MessangerClientApp.Infrastructure.Api.Clients;
using MessangerClientApp.Infrastructure.Repositories;
using MessangerClientApp.Infrastructure.Services;
using MessangerClientApp.Presentation.View.Pages;
using MessangerClientApp.Presentation.ViewModels;
using MessangerClientApp.View.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;
using System.Net.Http.Headers;
using System.Windows;

namespace MessangerClientApp
{
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

            navigationService.Configure("AuthPage", typeof(AuthPage));
            navigationService.Configure("RegPage", typeof(RegPage));
            navigationService.Configure("ChatPage", typeof(ChatPage));
            navigationService.Configure("ChatListPage", typeof(ChatListPage));
            navigationService.Configure("HomePage", typeof(HomePage));
            navigationService.Configure("SettingsPage", typeof(SettingsPage));

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

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("logs/app-.log", rollingInterval: RollingInterval.Day) 
            .CreateLogger();

            Log.Information("Application is initialized");

            services.AddTransient<UserService>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<MainViewModel>();
            services.AddTransient<AuthViewModel>();
            services.AddTransient<RegViewModel>();
            services.AddTransient<ChatViewModel>();
            services.AddTransient<ChatListViewModel>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<SettingsViewModel>();

            services.AddTransient<AuthPage>();
            services.AddTransient<RegPage>();
            services.AddTransient<ChatPage>();
            services.AddTransient<ChatListPage>();
            services.AddTransient<HomePage>();
            services.AddTransient<SettingsPage>();

            _serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            (_serviceProvider as IDisposable)?.Dispose();
            Log.Information("Application is closed");
            Log.CloseAndFlush();
            base.OnExit(e);
        }
    }

}
