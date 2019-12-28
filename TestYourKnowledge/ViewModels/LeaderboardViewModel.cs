using Domino.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace Domino.ViewModels
{
    internal class LeaderboardViewModel : BaseViewModel
    {
        private List<Person> _top10;
        public List<Person> Top10
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
                reader.ReadLine();
                var people = new List<Person>();
                while (!reader.EndOfStream)
                {
                    var person = reader.ReadLine().Split(';');
                    people.Add(new Person(person[0], int.Parse(person[1]), int.Parse(person[2])));
                }
                var peopleInOrder = people.OrderByDescending(x => x.Level).ThenBy(x => x.Time).ToList();
                for (int i = 0; i < (peopleInOrder.Count < 10 ? peopleInOrder.Count : 10); i++)
                {
                    Top10.Add(peopleInOrder[i]);
                }
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
            Top10 = new List<Person>();
            LoadFromFile("Leaderboard.csv");
        }
    }
}
