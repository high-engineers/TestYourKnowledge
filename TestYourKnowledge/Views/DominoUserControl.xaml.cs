using Domino.Models;
using Domino.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Domino.Views
{
    /// <summary>
    /// Interaction logic for DominoUserControl.xaml
    /// </summary>
    public partial class DominoUserControl : UserControl
    {
        public DominoUserControl()
        {
            InitializeComponent();
        }

        private void Domino_Drop(object sender, DragEventArgs e)
        {
            var source = e.Data.GetData(typeof(DominoModel)) as DominoModel;
            if (source.IsCorrect)
            {
                GameViewModel.CorrectDomino = true;
            }
            else
            {
                GameViewModel.GameEnded = true;
            }
        }
    }
}
