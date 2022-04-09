using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Interface
{
    public interface IBooksRepository
    {
        bool AddBook(IBook book);
        bool RemoveBook(IBook book);
        List<IBook> FindBooksByPredicate(Predicate<IBook> predicate);
    }
}
