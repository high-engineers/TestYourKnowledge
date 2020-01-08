using System.IO;
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
                OnPropertyChanged(nameof(Name));
            }
        }

        private int _timeFromStart;
        public int TimeFromStart
        {
            get => _timeFromStart;
            set
            {
                _timeFromStart = value;
                OnPropertyChanged(nameof(TimeFromStart));
            }
        }

        public ICommand MainMenuCommand { get; set; }

        public ICommand PlayAgainCommand { get; set; } = new RelayCommand<object>((x) =>
                ApplicationViewModel.Instance.CurrentPage = AppPage.Game);

        public SumUpViewModel()
        {
            MainMenuCommand = new RelayCommand<object>(GoToMainMenu);
            TimeFromStart = ApplicationViewModel.Instance.TimeStart.GetSecondsDifferenceFromNow();
        }

        public void GoToMainMenu(object x)
        {
            SaveToFile(ApplicationViewModel.LeaderboardPath);
            ApplicationViewModel.Instance.CurrentPage = AppPage.MainMenu;
        }

        public void SaveToFile(string path)
        {
            var playerResult = new PlayerResultModel
            {
                Name = Name,
                TimeResult = TimeFromStart
            };
            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{playerResult.Name};{playerResult.TimeResult}");
            }
        }
    }
}