using System;
using System.Threading.Tasks;

namespace Library.Data.Interface
{
    public interface ILibraryDataLayer
    {
        IBooksRepository GetBooksRepository();
        IPersonsRepository GetPersonsRepository();
        ILendingsRepository GetLendingsRepository();
        event Action<string> onConnectionMessage;
        Task Connect(Uri uri);
        Task SendMessage(string message);
        void ConnectionMessageHandler(string message);
    }
}