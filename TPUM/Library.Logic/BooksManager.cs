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

        public bool CreateBook(BookInfo initData)
        {
            CreateBookFactory factory = new CreateBookFactory(initData);
            return _library.dataLayer.GetBooksRepository().AddBook(factory.Create());
        }

        public List<BookInfo> GetBooks(IFilter<BookInfo> filter)
        {
            return _library.dataLayer.GetBooksRepository().GetBooks().ConvertAll(Library.ToBookInfo)
                .FindAll(filter.Match);
        }

        public bool UpdateBook(BookInfo original, BookInfo updated)
        {
            IBooksRepository repository = _library.dataLayer.GetBooksRepository();
            // If the updated book has changed ID, check if this ID is not already taken by other book
            if (updated.id != original.id)
            {
                bool exists = repository.FindBooksByPredicate(item => item.GetBookID() == updated.id).Count > 0;
                if (exists)
                {   // If it is, we can't perform the update.
                    return false;
                }
            }

            // There should never be more than 1 book with the same ID, but we sanity check anyways.
            List<IBook> oldBook = repository.FindBooksByPredicate(item => item.GetBookID() == original.id);
            if (oldBook.Count != 1)
            {
                return false;
            }

            /* ++++ Atomic Operation ++++ */
            bool removed = repository.RemoveBook(oldBook[0]);
            if (!removed)
            {
                return false;
            }
            bool added = repository.AddBook(Library.ToBook(updated));
            /* ---- Atomic Operation ---- */
            return added;
        }

        public bool RemoveBook(BookInfo book)
        {
            List<IBook> target = _library.dataLayer.GetBooksRepository()
                .FindBooksByPredicate(item => item.GetBookID() == book.id);
            if (target.Count != 1)
            {
                return false;
            }
            return _library.dataLayer.GetBooksRepository().RemoveBook(target[0]);
        }
    }
}