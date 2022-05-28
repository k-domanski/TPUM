using System;
using System.Collections.Generic;
using Library.DataServer.Interface;

namespace Library.DataServer
{
    public class BooksRepository : IBooksRepository
    {
        public event Action<IBook> onBookAdded;
        public event Action<IBook> onBookRemoved;

        private List<IBook> _books;
        private readonly object _dataLock = new object();

        public BooksRepository()
        {
            _books = new List<IBook>();
        }


        public List<IBook> GetBooks()
        {
            lock (_dataLock)
            {
                return new List<IBook>(_books);
            }
        }

        public bool AddBook(IBook book)
        {
            lock (_dataLock)
            {
                if (_books.Contains(book))
                {
                    return false;
                }
                _books.Add(book);
                onBookAdded?.Invoke(book);
                return true;
            }
        }

        public bool RemoveBook(IBook book)
        {
            lock (_dataLock)
            {
                if (_books.Remove(book))
                {
                    onBookRemoved?.Invoke(book);
                    return true;
                }

                return false;
            }
        }

        public List<IBook> FindBooksByPredicate(Predicate<IBook> predicate)
        {
            lock (_dataLock)
            {
                return _books.FindAll(predicate);
            }
        }
    }
}
