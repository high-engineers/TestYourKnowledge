using System.IO;
using System.Windows.Input;
using TestYourKnowledge.Extensions;
using TestYourKnowledge.Models;

namespace TestYourKnowledge.ViewModels
{
    internal class SumUpViewModel : BaseViewModel
    {
        private string _name;
        public string Name
        {
            get => _name ?? string.Empty;
            set
            {
                _name = value;
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

        private int _level;
        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }

        public ICommand MainMenuCommand { get; set; }
        public ICommand PlayAgainCommand { get; set; }
        public void GoToMainMenu()
        {
            SaveToFile("Leaderboard.csv");
            ApplicationViewModel.Instance.CurrentPage = AppPage.MainMenu;
        }

        public void SaveToFile(string path)
        {
            var playerResult = new PlayerResultModel
            {
                Name = Name,
                Level = Level,
                TimeResult = TimeFromStart
            };
            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{playerResult.Name};{playerResult.TimeResult};{playerResult.Level}");
            }
        }

        public void PlayAgain()
        {
            ApplicationViewModel.Instance.CurrentPage = AppPage.Game;
        }

        public SumUpViewModel()
        {
            MainMenuCommand = new RelayCommand(GoToMainMenu);
            PlayAgainCommand = new RelayCommand(PlayAgain);
            TimeFromStart = ApplicationViewModel.Instance.Game.TimeStart.GetSecondsDifferenceFromNow();
            Level = ApplicationViewModel.Instance.Game.LevelAchieved;
            Name = ApplicationViewModel.Instance.UserSetup.Name;
        }
    }
}