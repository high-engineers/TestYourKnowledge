using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestYourKnowledge.Models;
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
            var gameViewModel = DataContext as GameViewModel;

            if (!(e.Data.GetData(typeof(Resource)) is Resource sound))
            {
                return;
            }

            var border = sender as Border;

            if (!(border.DataContext is Resource image))
            {
                return;
            }

            (border.Child as TextBlock).Text = sound.Index.ToString();

            gameViewModel.AssignSoundToImage(sound, image);
        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var button = sender as Button;
            DragDrop.DoDragDrop(button, button.DataContext, DragDropEffects.All);
        }
    }
}
