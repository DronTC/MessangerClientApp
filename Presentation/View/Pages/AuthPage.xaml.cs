using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using MessangerClientApp.ViewModels;

namespace MessangerClientApp.View.Pages
{
    public partial class AuthPage : Page
    {
        public AuthPage(AuthViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            var viewModel = DataContext as AuthViewModel;

            if (viewModel != null)
            {
                viewModel.PasswordValue = passwordBox.Password;
            }
        }
    }
}
