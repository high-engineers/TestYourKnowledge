using System.Windows.Input;
using TestYourKnowledge.Models;

namespace TestYourKnowledge.ViewModels
{
    internal class UserSetupViewModel : BaseViewModel
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

        public static string ConfirmedName;

        public ICommand MainMenuCommand { get; set; }
        public ICommand PlayCommand { get; set; }

        public void GoToMainMenu()
        {
            ApplicationViewModel.Instance.CurrentPage = AppPage.MainMenu;
        }

        public void Play()
        {
            ConfirmedName = Name;
            ApplicationViewModel.Instance.CurrentPage = AppPage.Game;
        }
        public UserSetupViewModel()
        {
            MainMenuCommand = new RelayCommand(GoToMainMenu);
            PlayCommand = new RelayCommand(Play);
        }
        //TODO: set clock? difficulty?
    }
}
