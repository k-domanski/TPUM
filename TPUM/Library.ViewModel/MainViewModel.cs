using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            _dataLayer = DataLayer.CreateDefault();
            _books = new ObservableCollection<Book>(_dataLayer.book);
            _users = new ObservableCollection<Person>(_dataLayer.user);
            _lendings = new ObservableCollection<Lending>(_dataLayer.lending);
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

        #region Private
        private ObservableCollection<Book> _books;
        private ObservableCollection<Person> _users;
        private ObservableCollection<Lending> _lendings;
        private DataLayer _dataLayer;
        #endregion
    }
}
