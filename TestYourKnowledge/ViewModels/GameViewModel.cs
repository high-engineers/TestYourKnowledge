using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Media;
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

        private List<Resource> _images = new List<Resource>();
        public List<Resource> Images
        {
            get => _images;
            set
            {
                _images = value;
                OnPropertyChanged(nameof(Images));
            }
        }

        private List<Resource> _sounds = new List<Resource>();
        public List<Resource> Sounds
        {
            get => _sounds;
            set
            {
                _sounds = value;
                OnPropertyChanged(nameof(Sounds));
            }
        }

        public GameViewModel()
        {
            ApplicationViewModel.Instance.TimeStart = DateTime.Now;
            UpdateGameStatus();
            //TODO: Load resources properly
            Sounds.AddRange(new List<Resource>
            {
                new Resource
                {
                    No = 1,
                    Path = "\\Resources\\1\\do not like.m4a"
                },
                new Resource
                {
                    No = 2,
                    Path = "\\Resources\\2\\book.m4a"
                },
                new Resource
                {
                    No = 3,
                    Path = "\\Resources\\3\\you.m4a"
                }
            });

            Images.AddRange(new List<Resource>
            {
                new Resource
                {
                    No = 1,
                    Path = "\\Resources\\1\\do not like.png"
                },
                new Resource
                {
                    No = 2,
                    Path = "\\Resources\\2\\book.jpg"
                },
                new Resource
                {
                    No = 3,
                    Path = "\\Resources\\3\\you.jpg"
                }
            });
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
