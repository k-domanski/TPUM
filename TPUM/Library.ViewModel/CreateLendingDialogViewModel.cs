using Library.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.ViewModel
{
    public class CreateLendingDialogViewModel : DialogViewModelBase<Lending>
    {
        public ICommand createLendingCommand { get; private set; }

        public ObservableCollection<Person> users { get => _modelLayer.users; }
        public ObservableCollection<Book> books { get => _modelLayer.books; }

        public Person selectedUser 
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                RaisePropertyChanged();
            }
        }
        public Book selectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                RaisePropertyChanged();
            }
        }

        public CreateLendingDialogViewModel(ModelLayer modelLayer, string title, string message) : base(title, message)
        {
            _modelLayer = modelLayer;
            _modelLayer.ShouldApplyOnlyAvailableFilter(true);
            createLendingCommand = new RelayCommand<IDialogWindow>(CreateLending);
        }

        private void CreateLending(IDialogWindow window)
        {
            if (selectedBook == null || selectedUser == null)
            {
                CloseDialogWithResult(window, null);
            }
            else
            {
                Lending newLending = new Lending { bookAuthor = _selectedBook.author, bookID = _selectedBook.id, bookTitle = _selectedBook.title,
                    userID = _selectedUser.id, userName = _selectedUser.firstName, userSurname = _selectedUser.lastName };
                CloseDialogWithResult(window, newLending);
            }
        }

        private ModelLayer _modelLayer;
        private Book _selectedBook;
        private Person _selectedUser;
    }
}
