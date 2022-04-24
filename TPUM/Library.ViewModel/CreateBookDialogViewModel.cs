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

        public Book book { get => _book; set { _book = value; } }

        public CreateBookDialogViewModel(string title, string message) : base(title, message)
        {
            _book = new Book();
            createBookCommand = new RelayCommand<IDialogWindow>(CreateBook);
        }

        private void CreateBook(IDialogWindow window)
        {
            CloseDialogWithResult(window, _book);
        }

        private Book _book;
    }
}
