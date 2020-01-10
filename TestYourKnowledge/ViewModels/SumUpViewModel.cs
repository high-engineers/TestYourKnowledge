﻿using System.IO;
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

        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        public ICommand MainMenuCommand { get; set; }

        public ICommand PlayAgainCommand { get; set; } = new RelayCommand<object>((x) =>
                ApplicationViewModel.Instance.CurrentPage = AppPage.Game);

        public SumUpViewModel()
        {
            MainMenuCommand = new RelayCommand<object>(GoToMainMenu);
            TimeFromStart = ApplicationViewModel.Instance.TimeStart.GetSecondsDifferenceFromNow();
            Score = ApplicationViewModel.Instance.CorrectAnswers + 1;
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
                TimeResult = TimeFromStart,
                Score = Score
            };
            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{playerResult.Name};{playerResult.TimeResult};{playerResult.Score}");
            }
        }
    }
}