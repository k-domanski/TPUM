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
        public ICommand createNewBookCommand { get; set; }
        public ICommand createNewUserCommand { get; set; }

        public IDialogService dialogService { get =>_dialogService; set { _dialogService = value; } }
        public MainViewModel()
        {
            _modelLayer = ModelLayer.CreateDefault();
            createNewBookCommand = new ViewAction(HandleCreateBook);
            createNewUserCommand = new ViewAction(HandleCreateUser);

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
        //public Lazy<IWindow> PersonWindow { get; set; }
        public void HandleCreateBook()
        {
            //TODO: Should open the book creation window instead

            
            _modelLayer.CreateBook(new Book{author = "Ala", title = "Ma Kota", isbn = "9870-234-456-234"});
        }

        public void HandleCreateUser()
        {
            var dialog = new AlertDialogViewModel("Attenction", "This is an alert!");
            var result = _dialogService.OpenDialog(dialog);
            string test = result;
            var dialog1 = new AlertDialogViewModel(test, "This is an alert!");
            var result1 = _dialogService.OpenDialog(dialog1);
            Console.WriteLine("KAEFSDJKLFKSLADKFLASDKF");
            //IWindow child = PersonWindow.Value;
            //child.Show();
        }
        #region Private

        private ModelLayer _modelLayer;
        private Book _currentBook;
        private Person _currentUser;
        private Lending _currentLending;
        private IDialogService _dialogService;
        #endregion
    }
}
