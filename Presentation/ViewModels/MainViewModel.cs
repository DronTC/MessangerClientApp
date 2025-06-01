using MessangerClientApp.Core.Collections;
using MessangerClientApp.Core.Commands;
using MessangerClientApp.Core.Models;
using MessangerClientApp.Infrastructure.Services;
using MessangerClientApp.Presentation.View.Pages;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows;
using System.Windows.Input;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace MessangerClientApp.Presentation.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private NavigationItem _selectedItem;
        private int _navigationBarWidth;
        public ObservableCollection<NavigationItem> MenuItems { get; }
        public ICommand ResizeCommand { get; private set; }
        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigationBarWidth = 120;

            MenuItems = NavigationItemsProvider.navigationItems;

            foreach (var item in MenuItems)
            {
                item.NavigateCommand = new RelayCommand<NavigationItem>(param =>
                {
                    SelectedItem = param;
                });
            };

            ResizeCommand = new RelayCommand(ExecuteResizeCommand);
        }
        private void ExecuteResizeCommand(object parameter)
        {
            if (NavigationBarWidth > 0)
                NavigationBarWidth = 0;
            else
                NavigationBarWidth = 120;
        }
        public NavigationItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != null)
                    _selectedItem.IsSelected = false;

                _selectedItem = value;
                if (_selectedItem != null)
                {
                    _selectedItem.IsSelected = true;
                    _navigationService.NavigateTo(_selectedItem.PageKey, "MainFrame");
                }

                OnPropertyChanged();
            }
        }
        public int NavigationBarWidth
        {
            get => _navigationBarWidth;
            set
            {
                if (_navigationBarWidth != value)
                {
                    _navigationBarWidth = value;
                    OnPropertyChanged(nameof(NavigationBarWidth));
                }
            }
        }
    }
}
