using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Interface;

namespace Library.Data
{
    public class BooksRepository : IBooksRepository
    {
        public event Action<IBook> onBookAdded;
        public event Action<IBook> onBookRemoved;

        private List<IBook> _books;

        public BooksRepository()
        {
            _books = new List<IBook>();
        }


        public List<IBook> GetBooks()
        {
            return _books;
        }

        public bool AddBook(IBook book)
        {
            if (_books.Contains(book))
            {
                return false;
            }
            _books.Add(book);
            onBookAdded?.Invoke(book);
            return true;
        }

        public bool RemoveBook(IBook book)
        {
            if (_books.Remove(book))
            {
                onBookRemoved?.Invoke(book);
                return true;
            }

            return false;
        }

        public List<IBook> FindBooksByPredicate(Predicate<IBook> predicate)
        {
            return _books.FindAll(predicate);
        }
    }
}
