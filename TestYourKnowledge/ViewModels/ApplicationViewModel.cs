using System;
using System.Collections.Generic;
using System.Linq;
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

        public string Name { get; set; }
        public DateTime TimeStart { get; set; }
        public int GetCorrectAnswersCount()
        {
            return ImageStatistics.Values.Where(x => x.IsCorrect).ToList().Count;
        }

        public IDictionary<int, SoundStatisticsModel> SoundStatistics { get; set; } = new Dictionary<int, SoundStatisticsModel>();
        public IDictionary<int, ImageStatisticsModel> ImageStatistics { get; set; } = new Dictionary<int, ImageStatisticsModel>();
        public void InitializeStatistics(IList<int> resourceNumbers)
        {
            SoundStatistics = new Dictionary<int, SoundStatisticsModel>();
            ImageStatistics = new Dictionary<int, ImageStatisticsModel>();
            foreach(var no in resourceNumbers.OrderBy(x => x))
            {
                SoundStatistics.Add(no, new SoundStatisticsModel
                {
                    ClickedCount = 0
                });

                ImageStatistics.Add(no, new ImageStatisticsModel
                {
                    IsCorrect = false
                });
            }
        }
        #region Instance
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
