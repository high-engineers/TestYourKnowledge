using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TestYourKnowledge.Extensions;
using TestYourKnowledge.Models;


namespace TestYourKnowledge.ViewModels
{
    internal class GameViewModel : BaseViewModel
    {
        public bool GameEnded { get; set; }
        private MediaPlayer _player = new MediaPlayer();

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

        private ObservableCollection<Resource> _sounds = new ObservableCollection<Resource>();
        public ObservableCollection<Resource> Sounds
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
            ApplicationViewModel.Instance.CorrectAnswers = 0;
            PlaySoundCommand = new RelayCommand<string>(PlaySound);
            LoadResources();
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
                Application.Current.Dispatcher.Invoke(() => _player.Close());
                ApplicationViewModel.Instance.CurrentPage = AppPage.SumUp;
            });
        }

        private void LoadResources()
        {
            var sounds = new List<Resource>();
            int noCounter = 1;
            while (true)
            {
                string path = @"Resources\" + noCounter.ToString();
                if (Directory.Exists(path))
                {
                    var filePaths = Directory.GetFiles(path);
                    if (filePaths.Length != 2)
                    {
                        //TODO: notify user that something is wrong in folder number {i}?
                    }
                    else
                    {
                        var firstResource = new Resource
                        {
                            No = noCounter,
                            Path = @"\" + filePaths[0]
                        };
                        var secondResource = new Resource
                        {
                            No = noCounter,
                            Path = @"\" + filePaths[1]
                        };

                        //one and only acceptable situation is two files per subfolder
                        //one resource is sound, one resource is image
                        //if any other situation - do not add any image or sound - kinda transactional
                        if (firstResource.IsSound() && secondResource.IsImage())
                        {
                            sounds.Add(firstResource);
                            Images.Add(secondResource);
                        }
                        else if (firstResource.IsImage() && secondResource.IsSound())
                        {
                            Images.Add(firstResource);
                            sounds.Add(secondResource);
                        }
                    }
                    noCounter++;
                }
                //if there is subfolder missing which breakes the number ordering it will stop and add only resources before missing subfolder
                else
                {
                    break;
                }
            }

            sounds = sounds.Shuffle();
            for (int i = 0; i < sounds.Count; i++)
            {
                sounds[i].Index = i+1;
                Sounds.Add(sounds[i]);
            }
            Images = Images.Shuffle();
        }

        public ICommand PlaySoundCommand { get; set; }

        private void PlaySound(string pathToSound)
        {
            _player.Open(new Uri(Directory.GetCurrentDirectory() + pathToSound));
            _player.Play();
        }

        public void AssignSoundToImage(Resource sound, Resource image)
        {
            if (Sounds.Contains(sound) && sound.No == image.No)
            {
                ApplicationViewModel.Instance.CorrectAnswers++;
            }

            Sounds.Remove(sound);

            if (Sounds.Count == 1)
            {
                GameEnded = true;
            }
        }
    }
}
