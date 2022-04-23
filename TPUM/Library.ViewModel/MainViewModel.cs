﻿using System;
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
        public ICommand createNewBookCommand { get; set; }

        public MainViewModel()
        {
            _modelLayer = ModelLayer.CreateDefault();

            createNewBookCommand = new ViewAction((obj) => HandleCreateBook(), null);
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

        public void HandleCreateBook()
        {
            _modelLayer.CreateBook(new Book{author = "Ala", title = "Ma Kota", isbn = "9870-234-456-234"});
        }
        #region Private

        private ModelLayer _modelLayer;
        #endregion
    }
}
