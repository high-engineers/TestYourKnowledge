using TestYourKnowledge.ViewModels;
using System.Windows;

namespace TestYourKnowledge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ApplicationViewModel.Instance;
        }
    }
}
