using System;
using System.Threading.Tasks;
using Library.LogicServer.Interface;

namespace Library.LogicServer
{
    public interface ILibrary
    {
        event Action<BookInfo> onBookAdded;
        event Action<PersonInfo> onPersonAdded;
        event Action<LendingInfo> onLendingAdded;
        event Action<BookInfo> onBookRemoved;
        event Action<PersonInfo> onPersonRemoved;
        event Action<LendingInfo> onLendingRemoved;

        void Initialize();

        IBooksManager GetBooksManager();
        IPersonsManager GetPersonsManager();
        ILendingsManager GetLendingsManager();
        bool LendBook(Guid bookID, Guid personID);
        bool ReturnBook(LendingInfo lending);
        bool CanLendBook(Guid bookID);
    }
}