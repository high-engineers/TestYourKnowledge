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
            LoadFromFile(ApplicationViewModel.LeaderboardPath);
        }

        public void LoadFromFile(string path)
        {
            var playerResults = new List<PlayerResultModel>();
            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        var playerResult = reader.ReadLine().Split(';');
                        playerResults.Add(new PlayerResultModel
                        {
                            Name = playerResult[0],
                            TimeResult = int.Parse(playerResult[1]),
                            Score = int.Parse(playerResult[2]),
                            TimeStart = DateTime.Parse(playerResult[3])
                        });
                    }

                    var i = 1;
                    Top10 = playerResults
                        .OrderByDescending(x => x.Score)
                        .ThenBy(x => x.TimeResult)
                        .Take(10)
                        .Select(x => new ResultLeaderboardModel
                        {
                            No = i++,
                            Name = x.Name,
                            TimeResult = x.TimeResult,
                            Score = x.Score,
                            TimeStart = x.TimeStart
                        }).ToList();
                }
            }
        }
    }
}
