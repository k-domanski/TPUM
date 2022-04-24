using System;

namespace Library.Data.Interface
{
    public interface IPerson : IEquatable<IPerson>
    {
        Guid GetID();
        string GetFirstName();
        string GetSurname();
    }
}
