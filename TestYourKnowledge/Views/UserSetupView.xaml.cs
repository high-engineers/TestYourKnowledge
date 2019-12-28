using System.Windows.Controls;
using TestYourKnowledge.ViewModels;

namespace TestYourKnowledge.Views
{
    /// <summary>
    /// Interaction logic for UserSetupView.xaml
    /// </summary>
    public partial class UserSetupView : Page
    {
        public UserSetupView()
        {
            InitializeComponent();
            DataContext = new UserSetupViewModel();
        }
    }
}
