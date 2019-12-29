using System;
using System.Threading.Tasks;
using TestYourKnowledge.Extensions;
using TestYourKnowledge.Models;

namespace TestYourKnowledge.ViewModels
{
    internal class GameViewModel : BaseViewModel
    {
        public bool GameEnded { get; set; }

        public string Name
        {
            get => ApplicationViewModel.Instance.Name;
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

        private int _level = 1;
        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }

        public GameViewModel()
        {
            ApplicationViewModel.Instance.TimeStart = DateTime.Now;
            UpdateGameStatus();
        }

        public void UpdateGameStatus()
        {
            Task.Run(() =>
            {
                while (!GameEnded)
                {
                    TimeFromStart = ApplicationViewModel.Instance.TimeStart.GetSecondsDifferenceFromNow();
                }

                ApplicationViewModel.Instance.CurrentPage = AppPage.SumUp;
            });
        }
    }
}
