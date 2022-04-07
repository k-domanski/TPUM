using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Interface
{
    public interface IPerson
    {
        Guid GetID();
        string GetFirstName();
        string GetSurname();
    }
}
