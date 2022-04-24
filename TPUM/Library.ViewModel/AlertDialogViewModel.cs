using System.Windows.Input;

namespace Library.ViewModel
{
    public class AlertDialogViewModel : DialogViewModelBase<string>
    {
        public ICommand OKCommand { get; private set; }

        public AlertDialogViewModel(string title, string message) : base(title, message)
        {
            OKCommand = new RelayCommand<IDialogWindow>(OK);
        }

        public void OK(IDialogWindow window)
        {
            CloseDialogWithResult(window, "Test");
        }
    }
}
