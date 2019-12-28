using TestYourKnowledge.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestYourKnowledge.ViewModels
{
    internal class GameViewModel : BaseViewModel
    {
        public static DateTime TimeStart { get; set; }
        public static int LevelAchieved { get; set; } = 0;
        public static bool GameEnded { get; set; }
        public static bool CorrectDomino { get; set; }
        public static string Name { get; set; }

        //public PlayerModel Person { get; set; }


        private const double TimeLevelMultiplier = 0.9;
        private const int MaxLevel = 2;

        private double _timePerAnswer = 30;
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

        private string _name;


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
            GameEnded = true;
            ApplicationViewModel.Instance.CurrentPage = AppPage.MainMenu;
        }

        public void SumUp()
        {
            LevelAchieved = Level;
            ApplicationViewModel.Instance.CurrentPage = AppPage.SumUp;
        }

        public ICommand MainMenuCommand { get; set; }

        public GameViewModel()
        {
            MainMenuCommand = new RelayCommand(GoToMainMenu);
            GameEnded = false;
            LevelAchieved = 0;
            TimeStart = DateTime.Now;
            Name = UserSetupViewModel.ConfirmedName;
            UpdateGameStatus();
        }
    }
}
