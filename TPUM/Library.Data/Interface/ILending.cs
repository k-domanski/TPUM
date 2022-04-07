using System;

namespace Library.Data.Interface
{
    public interface ILending : IEquatable<ILending>
    {
        Guid GetPersonID();
        Guid GetBookISBN();
    }
}