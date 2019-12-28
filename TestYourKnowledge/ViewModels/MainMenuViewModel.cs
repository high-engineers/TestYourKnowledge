using Domino.Models;
using System.Windows.Input;

namespace Domino.ViewModels
{
    internal class MainMenuViewModel : BaseViewModel
    {
        public void NewGame()
        {
            ApplicationViewModel.Instance.CurrentPage = AppPage.Game;
        }

        public void Leaderboard()
        {
            ApplicationViewModel.Instance.CurrentPage = AppPage.Leaderboard;
        }

        public ICommand NewGameCommand { get; set; }
        public ICommand LeaderboardCommand { get; set; }

        public MainMenuViewModel()
        {
            NewGameCommand = new RelayCommand(NewGame);
            LeaderboardCommand = new RelayCommand(Leaderboard);
        }
    }
}
