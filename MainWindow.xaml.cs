using MessangerClientApp.Core.Interfaces;
using MessangerClientApp.View.Pages;
using System.Windows;
using System.Windows.Input;

namespace MessangerClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(INavigationService navigationService)
        {
            InitializeComponent();

            navigationService.RegisterFrame("MainFrame", MainFrame);
            navigationService.RegisterFrame("ChatFrame", ChatFrame);

            navigationService.Configure("AuthPage", typeof(AuthPage));
            navigationService.Configure("RegPage", typeof(RegPage));
            navigationService.Configure("ChatPage", typeof(ChatPage));
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
            
        }
    }
}