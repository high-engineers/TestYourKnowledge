using System.Windows.Input;
using TestYourKnowledge.Models;

namespace TestYourKnowledge.ViewModels
{
    internal class UserSetupViewModel : BaseViewModel
    {
        public string Name
        {
            get => ApplicationViewModel.Instance.Name;
            set
            {
                ApplicationViewModel.Instance.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ICommand MainMenuCommand { get; set; } = new RelayCommand<object>((x) =>
            ApplicationViewModel.Instance.CurrentPage = AppPage.MainMenu);

        public ICommand PlayCommand { get; set; } = new RelayCommand<object>((x) =>
            ApplicationViewModel.Instance.CurrentPage = AppPage.Game);
    }
}
