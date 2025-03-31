using MessangerClientApp.Core.Interfaces;
using MessangerClientApp.Core.Services;
using MessangerClientApp.View.Pages;
using MessangerClientApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
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
            navigationService.NavigateTo("AuthPage", "MainFrame");
        }
        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<MainWindow>();

            services.AddSingleton<IServiceProvider>(provider => provider);
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddTransient<AuthViewModel>();
            services.AddTransient<RegViewModel>();
            services.AddTransient<ChatViewModel>();

            services.AddTransient<AuthPage>();
            services.AddTransient<RegPage>();
            services.AddTransient<ChatPage>();

            _serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            (_serviceProvider as IDisposable)?.Dispose();
            base.OnExit(e);
        }
    }

}
