using TestYourKnowledge.ViewModels;
using System.Windows.Controls;

namespace TestYourKnowledge.Views
{
    /// <summary>
    /// Interaction logic for LeaderboardView.xaml
    /// </summary>
    public partial class LeaderboardView : Page
    {
        public LeaderboardView()
        {
            InitializeComponent();
            DataContext = new LeaderboardViewModel();
        }
    }
}
