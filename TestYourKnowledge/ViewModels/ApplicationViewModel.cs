using TestYourKnowledge.Models;

namespace TestYourKnowledge.ViewModels
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

        private UserSetupModel _userSetup = null;
        public UserSetupModel UserSetup
        {
            get => _userSetup;
            set
            {
                _userSetup = value;
                OnPropertyChanged(nameof(UserSetup));
            }
        }

        private GameModel _game = null;
        public GameModel Game
        {
            get => _game;
            set
            {
                _game = value;
                OnPropertyChanged(nameof(Game));
            }
        }

        #region Instances
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
        #endregion
    }
}
