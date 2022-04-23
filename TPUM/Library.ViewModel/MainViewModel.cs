using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Model;

namespace Library.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            _modelLayer = ModelLayer.CreateDefault();
            _books = new ObservableCollection<Book>(_modelLayer.book);
            _users = new ObservableCollection<Person>(_modelLayer.user);
            _lendings = new ObservableCollection<Lending>(_modelLayer.lending);

            createNewBookCommand = new ViewAction((obj) => HandleCreateBook(), null);
        }
        public ObservableCollection<Book> books
        {
            get => _books;
            set
            {
                _books = value;
            }
        }
        public ObservableCollection<Person> people
        {
            get => _users;
            set
            {
                _users = value;
            }
        }

        public ObservableCollection<Lending> lendings
        {
            get => _lendings;
            set
            {
                _lendings = value;
            }
        }

        public void HandleCreateBook()
        {
            _modelLayer.CreateBook(new Book{author = "Ala", title = "Ma Kota", isbn = "9870-234-456-234"});
        }

        public ICommand createNewBookCommand { get; set; }

        #region Private
        private ObservableCollection<Book> _books;
        private ObservableCollection<Person> _users;
        private ObservableCollection<Lending> _lendings;
        private ModelLayer _modelLayer;
        #endregion
    }
}
