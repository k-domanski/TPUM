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
            return true;
        }

        public bool RemoveBook(IBook book)
        {
            return _books.Remove(book);
        }

        public List<IBook> FindBooksByPredicate(Predicate<IBook> predicate)
        {
            return _books.FindAll(predicate);
        }
    }
}
