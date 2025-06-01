using System.Windows.Controls;

namespace MessangerClientApp.Infrastructure.Services
{
    public interface INavigationService
    {
        void RegisterFrame(string frameKey, Frame frame);
        void Configure(string pageKey, Type pageType);
        void NavigateTo(string pageKey, string frameName);
        void ClearFrame(string framekey);
    }
}
