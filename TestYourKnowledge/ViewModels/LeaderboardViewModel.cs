using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using TestYourKnowledge.Models;

namespace TestYourKnowledge.ViewModels
{
    internal class LeaderboardViewModel : BaseViewModel
    {
        private List<ResultLeaderboardModel> _top10;
        public List<ResultLeaderboardModel> Top10
        {
            get => _top10;
            set
            {
                _top10 = value;
                OnPropertyChanged(nameof(Top10));
            }
        }

        public void LoadFromFile(string path)
        {
            using (var reader = new StreamReader(path))
            {
                var playerResults = new List<PlayerResultModel>();
                while (!reader.EndOfStream)
                {
                    var playerResult = reader.ReadLine().Split(';');
                    playerResults.Add(new PlayerResultModel
                    {
                        Name = playerResult[0],
                        TimeResult = int.Parse(playerResult[1]),
                        Level = int.Parse(playerResult[2]),
                    });
                }

                var orderedPlayerResults = playerResults
                    .OrderByDescending(x => x.Level)
                    .ThenBy(x => x.TimeResult)
                    .Take(10)
                    .ToList();

                foreach (var item in orderedPlayerResults.Select((value, i) => new { i, value }))
                {
                    Top10.Add(new ResultLeaderboardModel
                    {
                        Number = item.i + 1,
                        Name = item.value.Name,
                        Level = item.value.Level,
                        TimeResult = item.value.TimeResult
                    });
                };
            }
        }

        public void GoToMainMenu()
        {
            ApplicationViewModel.Instance.CurrentPage = AppPage.MainMenu;
        }

        public ICommand MainMenuCommand { get; set; }

        public LeaderboardViewModel()
        {
            MainMenuCommand = new RelayCommand(GoToMainMenu);
            Top10 = new List<ResultLeaderboardModel>();
            LoadFromFile("Leaderboard.csv");
        }
    }
}
