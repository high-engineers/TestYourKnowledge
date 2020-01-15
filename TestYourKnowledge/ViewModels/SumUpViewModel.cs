using System.Windows.Input;
using TestYourKnowledge.Extensions;
using TestYourKnowledge.Models;

namespace TestYourKnowledge.ViewModels
{
    internal class SumUpViewModel : BaseViewModel
    {
        public string Name
        {
            get => ApplicationViewModel.Instance.Name ?? string.Empty;
            set
            {
                ApplicationViewModel.Instance.Name = value;
            }
        }
        public int TimeFromStart { get; set; }
        public int Score { get; set; }

        public ICommand MainMenuCommand { get; set; }

        public ICommand PlayAgainCommand { get; set; } = new RelayCommand<object>((x) =>
                ApplicationViewModel.Instance.CurrentPage = AppPage.Game);

        public SumUpViewModel()
        {
            MainMenuCommand = new RelayCommand<object>(GoToMainMenu);
            TimeFromStart = ApplicationViewModel.Instance.TimeStart.GetSecondsDifferenceFromNow();
            Score = ApplicationViewModel.Instance.StatisticsManager.GetCorrectAnswersCount();
        }

        public void GoToMainMenu(object x)
        {
            FileHandler.SavePlayerResult(BuildPlayerResultModel());
            ApplicationViewModel.Instance.CurrentPage = AppPage.MainMenu;
        }
        private PlayerResultModel BuildPlayerResultModel()
        {
            return new PlayerResultModel
            {
                Name = Name,
                TimeResult = TimeFromStart,
                Score = Score,
                MaxScore = ApplicationViewModel.Instance.StatisticsManager.NumberOfItems,
                TimeStart = ApplicationViewModel.Instance.TimeStart
            };
        }
    }
}