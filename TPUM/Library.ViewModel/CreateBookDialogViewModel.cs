using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.ViewModel
{
    public class CreateBookDialogViewModel : DialogViewModelBase<Book>
    {
        public ICommand createBookCommand { get; private set; }

        public Book newBook { get; set; }

        public CreateBookDialogViewModel(string title, string message) : base(title, message)
        {
            createBookCommand = new RelayCommand<IDialogWindow>(CreateBook);
        }

        private void CreateBook(IDialogWindow window)
        {
            CloseDialogWithResult(window, newBook);
        }
    }
}
