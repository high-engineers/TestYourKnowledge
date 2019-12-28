using System.ComponentModel;

namespace TestYourKnowledge.Models
{
    internal class DominoModel : INotifyPropertyChanged
    {
        private string _leftImagePath = "/Images/";
        public string LeftImagePath
        {
            get => _leftImagePath;
            set
            {
                _leftImagePath = value;
                OnPropertyChanged(nameof(LeftImagePath));
            }
        }

        private string _rightImagePath = "/Images/";
        public string RightImagePath
        {
            get => _rightImagePath;
            set
            {
                _rightImagePath = value;
                OnPropertyChanged(nameof(RightImagePath));
            }
        }

        private bool _horizontal;
        public bool Horizontal
        {
            get => _horizontal;
            set
            {
                _horizontal = value;
                OnPropertyChanged(nameof(Horizontal));
            }
        }
        private bool _vertical;
        public bool Vertical
        {
            get => _vertical;
            set
            {
                _vertical = value;
                OnPropertyChanged(nameof(Vertical));
            }
        }
        private bool _allowDrop;
        public bool AllowDrop
        {
            get => _allowDrop;
            set
            {
                _allowDrop = value;
                OnPropertyChanged(nameof(AllowDrop));
            }
        }
        public bool IsCorrect { get; set; }

        public DominoModel(int level, int pictureLeft, int pictureRight, bool horizontal, bool correct)
        {
            LeftImagePath += level.ToString() + "/" + pictureLeft.ToString() + ".png";
            RightImagePath += level.ToString() + "/" + pictureRight.ToString() + ".png";
            Horizontal = horizontal;
            Vertical = !horizontal;
            IsCorrect = correct;
        }

        public DominoModel(bool horizontal)
        {
            Horizontal = horizontal;
            Vertical = !horizontal;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
