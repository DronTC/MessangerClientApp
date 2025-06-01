using MessangerClientApp.Presentation.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MessangerClientApp.Core.Models
{
    public class NavigationItem: INotifyPropertyChanged
    {
        private bool _isSelected;

        public string Title { get; set; }
        public string Icon { get; set; }
        public string PageKey { get; set; }
        public ICommand NavigateCommand { get; set; }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
