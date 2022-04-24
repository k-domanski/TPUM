using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Model;
using System.Windows;

namespace Library.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand showOnlyAvailableCommand { get; set; }
        public ICommand createNewBookCommand { get; set; }
        public ICommand createNewUserCommand { get; set; }

        public IDialogService createBookService { get =>_createBookService; set { _createBookService = value; } }
        public IDialogService createUserSercive { get =>_createUserService; set { _createUserService = value; } }

        public MainViewModel()
        {
            _modelLayer = ModelLayer.CreateDefault();
            createNewBookCommand = new ViewAction(HandleCreateBook);
            createNewUserCommand = new ViewAction(HandleCreateUser);
            showOnlyAvailableCommand = new RelayCommand<object>(HandleShowOnlyAvailable);
        }
        public ObservableCollection<Book> books
        {
            get => _modelLayer.books;
        }
        public ObservableCollection<Person> people
        {
            get => _modelLayer.users;
        }

        public ObservableCollection<Lending> lendings
        {
            get => _modelLayer.lendings;
        }

        public Book currentBook
        {
            get => _currentBook;
            set
            {
                _currentBook = value;
                RaisePropertyChanged();
            }
        }

        public Person currentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                RaisePropertyChanged();
            }
        }

        public Lending currentLending
        {
            get => _currentLending;
            set
            {
                _currentLending = value;
                RaisePropertyChanged();
            }
        }

        public void HandleCreateBook()
        {
            //TODO: Should open the filteredBooks creation window instead
            var dialog = new CreateBookDialogViewModel("Dodaj", "Dodaj nową książkę.");
            var result = _createBookService.OpenDialog(dialog);

            _modelLayer.CreateBook(result);
        }

        public void HandleCreateUser()
        {
            var dialog = new CreateUserDialogViewModel("Dodaj", "Dodaj nowego użytkownika.");
            var result = _createUserService.OpenDialog(dialog);

            //TODO:: Create user _modelLayer.CreateUser(result);
        }

        public void HandleShowOnlyAvailable(object obj)
        {
            _modelLayer.ShouldApplyOnlyAvailableFilter((bool)obj);
        }
        #region Private

        private ModelLayer _modelLayer;
        private Book _currentBook;
        private Person _currentUser;
        private Lending _currentLending;
        private IDialogService _createBookService;
        private IDialogService _createUserService;
        #endregion
    }
}
