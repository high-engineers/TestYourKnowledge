using System;
using System.Windows.Input;

namespace TestYourKnowledge
{
    internal class RelayCommand<T> : ICommand
    {
        private Action<T> _action;
        private Func<bool> _canExecute;

        public RelayCommand(Action<T> action, Func<bool> canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public void Execute(object parameter)
        {
            _action((T)parameter);
        }
    }
}
