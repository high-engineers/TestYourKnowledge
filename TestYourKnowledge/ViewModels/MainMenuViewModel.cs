using TestYourKnowledge.Models;
using System.Windows.Input;

namespace TestYourKnowledge.ViewModels
{
    internal class MainMenuViewModel : BaseViewModel
    {
        public ICommand LeaderboardCommand { get; set; } = new RelayCommand(() => 
            ApplicationViewModel.Instance.CurrentPage = AppPage.Leaderboard);

        public ICommand UserSetupCommand { get; set; } = new RelayCommand(() =>
            ApplicationViewModel.Instance.CurrentPage = AppPage.UserSetup);
    }
}
