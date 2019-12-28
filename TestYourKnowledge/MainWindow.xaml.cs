using Domino.ViewModels;
using System.Windows;

namespace Domino
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
