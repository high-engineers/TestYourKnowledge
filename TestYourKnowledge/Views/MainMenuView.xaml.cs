using Domino.ViewModels;
using System.Windows.Controls;

namespace Domino.Views
{
    /// <summary>
    /// Interaction logic for MainMenuView.xaml
    /// </summary>
    public partial class MainMenuView : Page
    {
        public MainMenuView()
        {
            InitializeComponent();
            DataContext = new MainMenuViewModel();
        }
    }
}
