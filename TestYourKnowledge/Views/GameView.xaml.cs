﻿using System.Windows;
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

        private void DominoUserControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var userControl = sender as UserControl;
            DragDrop.DoDragDrop(userControl, userControl.DataContext, DragDropEffects.All);
        }
    }
}
