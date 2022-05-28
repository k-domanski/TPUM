using System;

namespace Library.DataServer.Interface
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
