using MessangerClientApp.Core.Models;
using MessangerClientApp.Presentation.View.Pages;
using MessangerClientApp.Presentation.ViewModels;
using MessangerClientApp.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerClientApp.Core.Collections
{
    public static class NavigationItemsProvider
    {
        public static ObservableCollection<NavigationItem> navigationItems = new ObservableCollection<NavigationItem>
        {
            new NavigationItem
            {
                Title = "Главная",
                Icon = "",
                PageKey="HomePage"
            },
            new NavigationItem
            {
                Title = "Чаты",
                Icon = "",
                PageKey="ChatListPage"
            },
            new NavigationItem
            {
                Title = "Настройки",
                Icon = "",
                PageKey="SettingsPage"
            }
        };
        public static ObservableCollection<NavigationItem> GetNavigationItems()
        {
            return navigationItems;
        }
    }
}
