using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestYourKnowledge.ViewModels;

namespace TestYourKnowledge.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Page
    {
        public GameView()
        {
            InitializeComponent();
            DataContext = new GameViewModel();
        }

        private void Sound_Drop(object sender, DragEventArgs e)
        {

        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var button = sender as Button;
            DragDrop.DoDragDrop(button, button.DataContext, DragDropEffects.All);
        }
    }
}
