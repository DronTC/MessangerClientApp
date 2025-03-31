using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MessangerClientApp.Core.Interfaces;

namespace MessangerClientApp.Core.Services
{
    internal class NavigationService: INavigationService
    {
        private readonly Dictionary<string, Frame> _frames = new Dictionary<string, Frame>();
        private readonly Dictionary<string, Type> _pages = new Dictionary<string, Type>();
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void RegisterFrame(string frameName, Frame frame)
        {
            if(string.IsNullOrEmpty(frameName))
                throw new ArgumentNullException(nameof(frameName));
            if(frame == null)
                throw new ArgumentNullException(nameof(frame));
            if (_frames.ContainsKey(frameName))
                throw new InvalidOperationException($"Frame с именем {frameName} уже зарегистрирован");

            _frames[frameName] = frame;
        }
        public void Configure(string pageKey, Type pageType)
        {
            if (string.IsNullOrEmpty(pageKey))
                throw new ArgumentNullException(nameof(pageKey));
            if (pageType == null)
                throw new ArgumentNullException(nameof(pageType));
            if (!typeof(Page).IsAssignableFrom(pageType))
                throw new ArgumentException($"Тип {pageType.Name} не является страницей");
            if (_pages.ContainsKey(pageKey))
                throw new InvalidOperationException($"Страница с ключом {pageKey} уже зарегистрирована");

            _pages[pageKey] = pageType;
        }
        public void NavigateTo(string pageKey, string frameName)
        {
            if (string.IsNullOrEmpty(pageKey))
                throw new ArgumentNullException(nameof(pageKey));

            if (string.IsNullOrEmpty(frameName))
                throw new ArgumentNullException(nameof(frameName));
            if (!_pages.TryGetValue(pageKey, out var pageType))
                throw new ArgumentException($"Страница {pageKey} не найдена");
            if (!_frames.TryGetValue(frameName, out var frame))
                throw new ArgumentException($"Frame {frameName} не найден");


            var page = _serviceProvider.GetService(pageType);

            if (page == null)
                throw new InvalidOperationException($"Не удалось создать страницу {pageType.Name}. Убедитесь, что она зарегистрирована в DI.");

            frame.Navigate(page);
        }
    }
}
