using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using TestYourKnowledge.Models;

namespace TestYourKnowledge.ViewModels
{
    internal class LeaderboardViewModel : BaseViewModel
    {
        public List<ResultLeaderboardModel> Top10 { get; set; } = new List<ResultLeaderboardModel>();

        public ICommand MainMenuCommand { get; set; } = new RelayCommand<object>((x) =>
                 ApplicationViewModel.Instance.CurrentPage = AppPage.MainMenu);

        public LeaderboardViewModel()
        {
            Top10 = FileHandler.LoadResults().Take(10).ToList();
        }

    }
}
