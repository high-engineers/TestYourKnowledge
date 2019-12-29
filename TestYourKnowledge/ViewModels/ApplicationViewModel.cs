using System;
using TestYourKnowledge.Models;

namespace TestYourKnowledge.ViewModels
{
    internal class ApplicationViewModel : BaseViewModel
    {
        public static string LeaderboardPath = "Leaderboard.csv";

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

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private DateTime _timeStart;
        public DateTime TimeStart
        {
            get => _timeStart;
            set
            {
                _timeStart = value;
                OnPropertyChanged(nameof(TimeStart));
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
