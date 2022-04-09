using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Interface
{
    public interface IPerson : IEquatable<IPerson>
    {
        Guid GetID();
        string GetFirstName();
        string GetSurname();
    }
}
