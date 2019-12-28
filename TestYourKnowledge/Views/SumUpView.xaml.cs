using TestYourKnowledge.ViewModels;
using System.Windows.Controls;

namespace TestYourKnowledge.Views
{
    /// <summary>
    /// Interaction logic for SumUpView.xaml
    /// </summary>
    public partial class SumUpView : Page
    {
        public SumUpView()
        {
            InitializeComponent();
            DataContext = new SumUpViewModel();
        }
    }
}
