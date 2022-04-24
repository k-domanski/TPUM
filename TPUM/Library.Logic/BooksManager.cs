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
        public event Action<BookInfo> onBookCreated;

        private Library _library;
        private readonly object _dataLock = new object();

        public BooksManager(Library library)
        {
            _library = library;
        }


        public bool CreateBook(BookInfo initData)
        {
            if (String.IsNullOrEmpty(initData.author) || String.IsNullOrEmpty(initData.title) || String.IsNullOrEmpty(initData.isbn))
            {
                return false;
            }

            lock (_dataLock)
            {
                CreateBookFactory factory = new CreateBookFactory(initData);
                IBook book = factory.Create();
                if (_library.dataLayer.GetBooksRepository().AddBook(book))
                {
                    onBookCreated?.Invoke(Library.ToBookInfo(book));
                    return true;
                }

                return false;
            }
        }

        public List<BookInfo> GetBooks(IFilter<BookInfo> filter)
        {
            lock (_dataLock)
            {
                return _library.dataLayer.GetBooksRepository().GetBooks().ConvertAll(Library.ToBookInfo).FindAll(filter.Match);
            }
        }

        public bool UpdateBook(BookInfo original, BookInfo updated)
        {
            lock (_dataLock)
            {
                IBooksRepository repository = _library.dataLayer.GetBooksRepository();
                if (updated.id != original.id)
                {
                    bool exists = repository.FindBooksByPredicate(item => item.GetBookID() == updated.id).Count > 0;
                    if (exists)
                    {
                        return false;
                    }
                }

                List<IBook> oldBook = repository.FindBooksByPredicate(item => item.GetBookID() == original.id);
                if (oldBook.Count != 1)
                {
                    return false;
                }

                bool removed = repository.RemoveBook(oldBook[0]);
                if (!removed)
                {
                    return false;
                }
                bool added = repository.AddBook(Library.ToBook(updated));
                return added;
            }
        }

        public bool RemoveBook(BookInfo book)
        {
            lock (_dataLock)
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
}