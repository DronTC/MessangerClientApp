using MessangerClientApp.Presentation.ViewModels;
using MessangerClientApp.ViewModels;
using System.Windows.Controls;

namespace MessangerClientApp.Presentation.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChatListPage.xaml
    /// </summary>
    public partial class ChatListPage : Page
    {
        public ChatListPage(ChatListViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}
