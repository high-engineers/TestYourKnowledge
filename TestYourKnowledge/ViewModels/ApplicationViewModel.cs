using System;
using System.Collections.Generic;
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

        public string Name { get; set; }
        public DateTime TimeStart { get; set; }
        public StatisticsManager StatisticsManager { get; set; }
        public void InitializeStatistics(IList<int> resourceNumbers)
        {
            StatisticsManager = new StatisticsManager(resourceNumbers);
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
