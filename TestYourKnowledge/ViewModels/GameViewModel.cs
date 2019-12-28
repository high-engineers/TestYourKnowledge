using Domino.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Domino.ViewModels
{
    internal class GameViewModel : BaseViewModel
    {
        public static DateTime TimeStart { get; set; }
        public static int LevelAchieved { get; set; } = 0;
        public static bool GameEnded { get; set; }
        public static bool CorrectDomino { get; set; }

        private const double TimeLevelMultiplier = 0.9;
        private const int MaxLevel = 2;

        private double _timePerAnswer = 30;
        private DateTime _currentAnswerTimeStart;
        private int _correctLevelAnswers = 0;

        private ObservableCollection<DominoModel> _currentDominos;
        public ObservableCollection<DominoModel> CurrentDominos
        {
            get => _currentDominos;
            set
            {
                _currentDominos = value;
                OnPropertyChanged(nameof(CurrentDominos));
            }
        }

        private DominoModel _dominoOne;
        public DominoModel DominoOne
        {
            get => _dominoOne;
            set
            {
                _dominoOne = value;
                OnPropertyChanged(nameof(DominoOne));
            }
        }

        private DominoModel _dominoTwo;
        public DominoModel DominoTwo
        {
            get => _dominoTwo;
            set
            {
                _dominoTwo = value;
                OnPropertyChanged(nameof(DominoTwo));
            }
        }

        private DominoModel _dominoThree;
        public DominoModel DominoThree
        {
            get => _dominoThree;
            set
            {
                _dominoThree = value;
                OnPropertyChanged(nameof(DominoThree));
            }
        }

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

        public void GoToNextLevel()
        {
            if (Level == MaxLevel)
            {
                GameEnded = true;
            }
            Level++;
            _timePerAnswer *= TimeLevelMultiplier;
            _correctLevelAnswers = 0;
            GetNewLevelDominos();
        }

        private void GetNewLevelDominos()
        {
            GetCurrentDominosAfterNewLevel();
            UpdateDominos();
        }

        private void GetCurrentDominosAfterNewLevel()
        {
            CurrentDominos.Clear();
            CurrentDominos.Add(new DominoModel(Level, 1, 2, true, false));
            var domino = new DominoModel(true)
            {
                AllowDrop = true
            };
            CurrentDominos.Add(domino);
            for (int i = 0; i < 11; i++)
            {
                CurrentDominos.Add(new DominoModel(false));
                CurrentDominos[i + 2].Vertical = false;
            }
        }

        public bool EndGame()
        {
            SumUp();
            return true;
        }


        public void PlaceDomino()
        {
            _correctLevelAnswers++;
            _currentAnswerTimeStart = DateTime.Now;
            UpdateDominos();
            if (_correctLevelAnswers == 12)
            {
                GoToNextLevel();
            }
            var leftPlus = _correctLevelAnswers <= 6 ? 1 : 2;
            var rightPlus = _correctLevelAnswers <= 6 ? 2 : 1;
            CurrentDominos[_correctLevelAnswers].LeftImagePath = "/Images/" + Level + "/" + (_correctLevelAnswers + leftPlus).ToString() + ".png";
            CurrentDominos[_correctLevelAnswers].RightImagePath = "/Images/" + Level + "/" + (_correctLevelAnswers + rightPlus).ToString() + ".png";
            CurrentDominos[_correctLevelAnswers + 1].Horizontal = _correctLevelAnswers != 5;
            CurrentDominos[_correctLevelAnswers + 1].Vertical = _correctLevelAnswers == 5;
            CurrentDominos[_correctLevelAnswers + 1].AllowDrop = true;
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
                    if (CorrectDomino)
                    {
                        CorrectDomino = false;
                        PlaceDomino();
                    }
                }
                EndGame();
            });
        }

        private void UpdateDominos()
        {
            var random = new Random();
            var correctDomino = random.Next(1, 3);

            int left, right;
            do
            {
                left = random.Next(1, 14);
            } while (left == _correctLevelAnswers + 2 || left == _correctLevelAnswers + 3);
            do
            {
                right = random.Next(1, 14);
            } while (right == _correctLevelAnswers + 2 || right == _correctLevelAnswers + 3);
            DominoOne = new DominoModel(Level, left, right, _correctLevelAnswers != 5, false);

            do
            {
                left = random.Next(1, 14);
            } while (left == _correctLevelAnswers + 2 || left == _correctLevelAnswers + 3);
            do
            {
                right = random.Next(1, 14);
            } while (right == _correctLevelAnswers + 2 || right == _correctLevelAnswers + 3);
            DominoTwo = new DominoModel(Level, left, right, _correctLevelAnswers != 5, false);

            do
            {
                left = random.Next(1, 14);
            } while (left == _correctLevelAnswers + 2 || left == _correctLevelAnswers + 3);
            do
            {
                right = random.Next(1, 14);
            } while (right == _correctLevelAnswers + 2 || right == _correctLevelAnswers + 3);
            DominoThree = new DominoModel(Level, left, right, _correctLevelAnswers != 5, false);

            var leftPlus = _correctLevelAnswers <= 5 ? 2 : 3;
            var rightPlus = _correctLevelAnswers <= 5 ? 3 : 2;

            if (correctDomino == 1)
            {
                DominoOne = new DominoModel(Level, _correctLevelAnswers + leftPlus, _correctLevelAnswers + rightPlus, _correctLevelAnswers != 5, true);
            }
            else if (correctDomino == 2)
            {
                DominoTwo = new DominoModel(Level, _correctLevelAnswers + leftPlus, _correctLevelAnswers + rightPlus, _correctLevelAnswers != 5, true);
            }
            else if (correctDomino == 3)
            {
                DominoThree = new DominoModel(Level, _correctLevelAnswers + leftPlus, _correctLevelAnswers + rightPlus, _correctLevelAnswers != 5, true);
            }
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
            _currentDominos = new ObservableCollection<DominoModel>();
            CurrentDominos = new ObservableCollection<DominoModel>();

            GetNewLevelDominos();
            MainMenuCommand = new RelayCommand(GoToMainMenu);
            GameEnded = false;
            LevelAchieved = 0;
            TimeStart = DateTime.Now;
            UpdateGameStatus();
        }
    }
}
