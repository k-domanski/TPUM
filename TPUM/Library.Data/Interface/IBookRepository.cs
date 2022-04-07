using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Interface
{
    public interface IBookRepository
    {
        bool AddBook(Guid isbn, string author, string title);
        bool RemoveBook(Guid isbn);
        List<IBook> FindBooksByPredicate(Predicate<IBook> predicate);
    }
}
