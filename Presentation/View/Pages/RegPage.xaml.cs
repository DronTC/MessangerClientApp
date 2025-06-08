using MessangerClientApp.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MessangerClientApp.View.Pages
{
    public partial class RegPage : Page
    {
        public RegPage(RegViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
        private void FirstPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            var viewModel = DataContext as RegViewModel;

            if (viewModel != null)
            {
                viewModel.PasswordValue = passwordBox.Password;
            }
        }
        private void SecondPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            var viewModel = DataContext as RegViewModel;

            if (viewModel != null)
            {
                viewModel.ConfPasswordValue = passwordBox.Password;
            }
        }
    }
}
