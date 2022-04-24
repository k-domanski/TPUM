using System;

namespace Library.Data.Interface
{
    public interface IBook : IEquatable<IBook>
    {
        Guid GetBookID();
        string GetISBN();
        string GetAuthor();
        string GetTitle();
        bool IsAvailable();
    }
}
