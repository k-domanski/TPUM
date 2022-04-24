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
            if (IsBookNotValid())
            {
                CloseDialogWithResult(window, null);
            }
            else
            {
                CloseDialogWithResult(window, _book);
            }
        }

        private bool IsBookNotValid()
        {
            return string.IsNullOrEmpty(_book.title)
                || string.IsNullOrEmpty(_book.author)
                || string.IsNullOrEmpty(_book.isbn);
        }

        private Book _book;
    }
}
