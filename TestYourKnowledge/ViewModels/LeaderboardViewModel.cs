using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using TestYourKnowledge.Models;

namespace TestYourKnowledge.ViewModels
{
    internal class LeaderboardViewModel : BaseViewModel
    {
        private List<ResultLeaderboardModel> _top10 = new List<ResultLeaderboardModel>();
        public List<ResultLeaderboardModel> Top10
        {
            get => _top10;
            set
            {
                _top10 = value;
                OnPropertyChanged(nameof(Top10));
            }
        }

        public ICommand MainMenuCommand { get; set; } = new RelayCommand(() =>
                 ApplicationViewModel.Instance.CurrentPage = AppPage.MainMenu);

        public LeaderboardViewModel()
        {
            LoadFromFile(ApplicationViewModel.LeaderboardPath);
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
                        TimeResult = int.Parse(playerResult[1])
                    });
                }

                var i = 1;
                Top10 = playerResults
                    .OrderBy(x => x.TimeResult)
                    .Take(10)
                    .Select(x => new ResultLeaderboardModel
                    {
                        No = i++,
                        Name = x.Name,
                        TimeResult = x.TimeResult
                    }).ToList();
            }
        }
    }
}
