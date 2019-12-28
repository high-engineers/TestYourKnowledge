using Domino.Models;

namespace Domino.ViewModels
{
    internal class ApplicationViewModel : BaseViewModel
    {
        private AppPage _currentPage = AppPage.MainMenu;
        public AppPage CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        private static ApplicationViewModel _instance;
        public static ApplicationViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ApplicationViewModel();
                }
                return _instance;
            }
            set => _instance = value;
        }
    }
}
