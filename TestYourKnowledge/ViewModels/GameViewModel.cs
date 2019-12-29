using System;
using System.Threading.Tasks;
using TestYourKnowledge.Models;

namespace TestYourKnowledge.ViewModels
{
    internal class GameViewModel : BaseViewModel
    {
        public static int LevelAchieved { get; set; } = 0;
        public static bool GameEnded { get; set; }
        public static bool CorrectDomino { get; set; }
        public static string Name { get; set; }

        private const double TimeLevelMultiplier = 0.9;
        private const int MaxLevel = 2;

        private double _timePerAnswer = 1;
        private DateTime _currentAnswerTimeStart;
        private int _correctLevelAnswers = 0;

        private int _timeLeft;
        public int TimeLeft
        {
            get => _timeLeft;
            set
            {
                _timeLeft = value;
                OnPropertyChanged(nameof(TimeLeft));
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

        public bool EndGame()
        {
            SumUp();
            return true;
        }

        public void UpdateGameStatus()
        {
            _currentAnswerTimeStart = DateTime.Now;
            Task.Run(() =>
            {
                while (!GameEnded)
                {
                    TimeLeft = (_currentAnswerTimeStart - DateTime.Now).Seconds + Convert.ToInt32(_timePerAnswer);
                    if (TimeLeft <= 0)
                    {
                        GameEnded = true;
                        EndGame();
                    }
                }
                EndGame();
            });
        }

        public void GoToMainMenu()
        {
            ApplicationViewModel.Instance.CurrentPage = AppPage.MainMenu;
            GameEnded = true;
        }

        public void SumUp()
        {
            ApplicationViewModel.Instance.Game.LevelAchieved = Level;
            ApplicationViewModel.Instance.CurrentPage = AppPage.SumUp;
        }

        public GameViewModel()
        {
            var now = DateTime.Now;

            GameEnded = false;
            LevelAchieved = 0;
            Name = ApplicationViewModel.Instance.UserSetup.Name;
            ApplicationViewModel.Instance.Game = new GameModel
            {
                TimeStart = now
            };
            UpdateGameStatus();
        }
    }
}
