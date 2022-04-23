using System;
using Library.Logic.Interface;

namespace Library.Logic
{
    public interface ILibrary
    {
        event Action<BookInfo> onBookAdded;
        event Action<PersonInfo> onPersonAdded;
        event Action<LendingInfo> onLendingAdded;

        void Initialize();

        IBooksManager GetBooksManager();
        IPersonsManager GetPersonsManager();
        ILendingsManager GetLendingsManager();
    }
}