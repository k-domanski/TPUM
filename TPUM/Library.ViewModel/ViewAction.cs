using System;
using System.Windows.Input;

namespace Library.ViewModel
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute = null;
        private readonly Func<T, bool> _canExecute = null;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute ?? (_ => true);
        }

        public bool CanExecute(object parameter) => _canExecute((T)parameter);

        public void Execute(object parameter) => _execute((T)parameter);
    }

    public class ViewAction : RelayCommand<object>
    {
        public ViewAction(Action execute, Func<bool> canExecute) : base(_ => execute(), _ => canExecute()) { }
        public ViewAction(Action execute) : base(_ => execute()) { }
    }
}