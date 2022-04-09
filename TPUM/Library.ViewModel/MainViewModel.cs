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
            _books = new ObservableCollection<Book>(new DataLayer().book);
        }
        public ObservableCollection<Book> books
        {
            get => _books;
            set
            {
                _books = value;
            }
        }



        #region Private
        private ObservableCollection<Book> _books;
        #endregion
    }
}
