using System.Collections.Generic;
using Library.Data.Interface;

namespace Library.Logic.Interface
{
    public interface IBooksManager
    {
        bool CreateBook(BookInfo initData);
        List<IBook> GetBooks(IFilter<IBook> filter);
        bool UpdateBook(IBook book, IBookFactory bookFactory);
        bool RemoveBook(IBook book);
    }
}