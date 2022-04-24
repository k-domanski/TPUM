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

        public MainViewModel()
        {
            _modelLayer = ModelLayer.CreateDefault();

            createNewBookCommand = new ViewAction((obj) => HandleCreateBook(), null);
            createNewUserCommand = new ViewAction((obj) => HandleCreateUser(), null);
            showOnlyAvailableCommand = new ViewAction(HandleShowOnlyAvailable, null);

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


        public Lazy<IWindow> PersonWindow { get; set; }
        public void HandleCreateBook()
        {
            //TODO: Should open the filteredBooks creation window instead
            _modelLayer.CreateBook(new Book{author = "Ala", title = "Ma Kota", isbn = "9870-234-456-234"});
        }

        public void HandleCreateUser()
        {
            IWindow child = PersonWindow.Value;
            child.Show();
        }

        public void HandleShowOnlyAvailable(object obj)
        {
            _modelLayer.ShouldApplyOnlyAvailableFilter((bool)obj);
        }
        #region Private

        private ModelLayer _modelLayer;
        #endregion
    }
}
