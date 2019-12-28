﻿using Domino.Models;
using System;
using System.IO;
using System.Windows.Input;

namespace Domino.ViewModels
{
    internal class SumUpViewModel : BaseViewModel
    {
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

        public Person Person { get; set; }

        public ICommand MainMenuCommand { get; set; }

        public void GoToMainMenu()
        {
            SaveToFile("Leaderboard.csv");
            ApplicationViewModel.Instance.CurrentPage = AppPage.MainMenu;
        }

        public void SaveToFile(string path)
        {
            Person = new Person(Name, Convert.ToInt32(TimeFromStart), Level);
            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{Person.Name};{Person.Time};{Person.Level}");
            }
            GameViewModel.GameEnded = false;
        }

        public SumUpViewModel()
        {
            MainMenuCommand = new RelayCommand(GoToMainMenu);
            TimeFromStart = Math.Round((DateTime.Now - GameViewModel.TimeStart).TotalSeconds);
            Level = GameViewModel.LevelAchieved;
        }
    }
}