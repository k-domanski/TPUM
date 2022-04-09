using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Interface
{
    public interface IBook : IEquatable<IBook>
    {
        Guid GetISBN();
        string GetAuthor();
        string GetTitle();
    }
}
