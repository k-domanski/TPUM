using System;
using System.Collections.Generic;
using Library.Data;
using Library.Data.Interface;
using Library.Logic.Factories;
using Library.Logic.Interface;

namespace Library.Logic
{
    public class BooksManager : IBooksManager
    {
        private Library _library;
        public BooksManager(Library library)
        {
            _library = library;
        }

        public bool CreateBook(BookInitData initData)
        {
            CreateBookFactory factory = new CreateBookFactory(initData);
            return _library.dataLayer.GetBooksRepository().AddBook(factory.Create());
        }

        public List<IBook> GetBooks(IFilter<IBook> filter)
        {
            return _library.dataLayer.GetBooksRepository().FindBooksByPredicate(filter.Match);
        }

        public bool UpdateBook(IBook book, IBookFactory bookFactory)
        {
            IBooksRepository repository = _library.dataLayer.GetBooksRepository();
            bool removed = repository.RemoveBook(book);
            if (!removed)
            {
                return false;
            }

            bool added = repository.AddBook(bookFactory.Create());
            return added;
        }

        public bool RemoveBook(IBook book)
        {
            return _library.dataLayer.GetBooksRepository().RemoveBook(book);
        }
    }
}