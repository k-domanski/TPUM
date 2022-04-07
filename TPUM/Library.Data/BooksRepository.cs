using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Interface;

namespace Library.Data
{
    public class BooksRepository : IBookRepository
    {
        private IBookFactory _bookFactory;
        private List<IBook> _books;

        public BooksRepository(IBookFactory bookFactory)
        {
            _bookFactory = bookFactory;
            if (_bookFactory == null)
            {
                throw new ArgumentNullException(nameof(bookFactory), "Book Factory can't be null");
            }
            _books = new List<IBook>();
        }

        public bool AddBook(Guid isbn, string author, string title)
        {
            IBook newBook = _bookFactory.CreateBook(isbn, author, title);
            if (_books.Exists(book => book.GetISBN() == newBook.GetISBN()))
            {
                return false;
            }
            _books.Add(newBook);
            return true;
        }

        public bool RemoveBook(Guid isbn)
        {
            return _books.RemoveAll((book) => book.GetISBN() == isbn) > 0;
        }

        public List<IBook> FindBooksByPredicate(Predicate<IBook> predicate)
        {
            return _books.FindAll(predicate);
        }
    }
}
