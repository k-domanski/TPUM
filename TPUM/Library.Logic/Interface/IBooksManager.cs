using System;
using System.Collections.Generic;
using Library.Data.Interface;

namespace Library.Logic.Interface
{
    public interface IBooksManager
    {
        event Action<BookInfo> onBookCreated;
        bool CreateBook(BookInfo initData);
        List<BookInfo> GetBooks(IFilter<BookInfo> filter);
        bool UpdateBook(BookInfo original, BookInfo updated);
        bool RemoveBook(BookInfo book);
    }
}