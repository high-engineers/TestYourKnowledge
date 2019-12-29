using TestYourKnowledge.Models;
using System;
using System.IO;
using System.Windows.Input;
using TestYourKnowledge.Extensions;

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

        private double _timeFromStart;
        public double TimeFromStart
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
            var person = new PlayerModel(Name, Convert.ToInt32(TimeFromStart), Level);
            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{person.Name};{person.TimeStart};{person.Level}");
            }
            GameViewModel.GameEnded = false;
        }

        public void PlayAgain()
        {
            ApplicationViewModel.Instance.CurrentPage = AppPage.Game;
        }

        public SumUpViewModel()
        {
            MainMenuCommand = new RelayCommand(GoToMainMenu);
            PlayAgainCommand = new RelayCommand(PlayAgain);
            //get from now ext
            TimeFromStart = ApplicationViewModel.Instance.Game.TimeStart.GetSecondsDifferenceFromNow();
            Level = ApplicationViewModel.Instance.Game.LevelAchieved;
            Name = ApplicationViewModel.Instance.UserSetup.Name;
        }
    }
}