using System;
using Library.Logic.Interface;

namespace Library.Logic
{
    public interface ILibrary
    {
        event Action<BookInfo> onBookAdded;
        IBooksManager GetBooksManager();
        IPersonsManager GetPersonsManager();
        ILendingsManager GetLendingsManager();
    }
}