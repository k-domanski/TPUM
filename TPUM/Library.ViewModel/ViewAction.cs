using System;
using System.Windows.Input;

namespace Library.ViewModel
{
    public class ViewAction : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public ViewAction(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_execute == null)
            {
                return false;
            }

            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}