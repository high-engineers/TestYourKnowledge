using TestYourKnowledge.Models;
using System.Windows.Input;

namespace TestYourKnowledge.ViewModels
{
    internal class MainMenuViewModel : BaseViewModel
    {
        public void Leaderboard()
        {
            ApplicationViewModel.Instance.CurrentPage = AppPage.Leaderboard;
        }
        public void UserSetup()
        {
            ApplicationViewModel.Instance.CurrentPage = AppPage.UserSetup;
        }
        public ICommand LeaderboardCommand { get; set; }
        public ICommand UserSetupCommand { get; set; }

        public MainMenuViewModel()
        {
            LeaderboardCommand = new RelayCommand(Leaderboard);
            UserSetupCommand = new RelayCommand(UserSetup);
        }
    }
}
