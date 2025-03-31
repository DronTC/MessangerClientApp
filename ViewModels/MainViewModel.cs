using MessangerClientApp.Core.Interfaces;

namespace MessangerClientApp.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
