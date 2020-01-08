using System;
using System.Windows.Input;

namespace TestYourKnowledge
{
    internal class RelayCommand<T> : ICommand
    {
        private Action<T> _action;

        public RelayCommand(Action<T> action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action((T)parameter);
        }
    }
}
