using System;
using System.Threading.Tasks;
using Library.Logic.Interface;

namespace Library.Logic
{
    public interface ILibrary
    {
        event Action<BookInfo> onBookAdded;
        event Action<PersonInfo> onPersonAdded;
        event Action<LendingInfo> onLendingAdded;
        event Action<BookInfo> onBookRemoved;
        event Action<PersonInfo> onPersonRemoved;
        event Action<LendingInfo> onLendingRemoved;
        event Action<string> onConnectionMessage;

        void Initialize();

        IBooksManager GetBooksManager();
        IPersonsManager GetPersonsManager();
        ILendingsManager GetLendingsManager();
        bool LendBook(Guid bookID, Guid personID);
        bool ReturnBook(LendingInfo lending);
        bool CanLendBook(Guid bookID);
        Task Connect(Uri uri);
    }
}