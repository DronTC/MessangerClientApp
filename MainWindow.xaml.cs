using MessangerClientApp.Infrastructure.Services;
using MessangerClientApp.Presentation.View.Pages;
using MessangerClientApp.Presentation.ViewModels;
using MessangerClientApp.View.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace MessangerClientApp
{
    public partial class MainWindow : Window
    {
        public MainWindow(INavigationService navigationService, MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            navigationService.RegisterFrame("MainFrame", MainFrame);
            navigationService.RegisterFrame("FullScreenFrame", FullScreenFrame);
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ResizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizedButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }
    }
}