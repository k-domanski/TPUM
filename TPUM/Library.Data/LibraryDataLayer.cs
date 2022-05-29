using System;
using System.Threading;
using System.Threading.Tasks;
using Library.Data.Interface;

namespace Library.Data
{
    public class LibraryDataLayer : ILibraryDataLayer
    {
        private IBooksRepository _booksRepository;
        private IPersonsRepository _personsRepository;
        private ILendingsRepository _lendingsRepository;

        public event Action<string> onConnectionMessage;

        private WebSocketConnection connection = null;
        private SynchronizationContext context = SynchronizationContext.Current;

        public static LibraryDataLayer CreateDefault()
        {
            return new LibraryDataLayer(new BooksRepository(), new PersonsRepository(), new LendingsRepository());
        }

        public LibraryDataLayer(IBooksRepository booksRepository, IPersonsRepository personsRepository,
            ILendingsRepository lendingsRepository)
        {
            _booksRepository = booksRepository;
            _personsRepository = personsRepository;
            _lendingsRepository = lendingsRepository;
            context = SynchronizationContext.Current;
        }

        public IBooksRepository GetBooksRepository()
        {
            return _booksRepository;
        }

        public IPersonsRepository GetPersonsRepository()
        {
            return _personsRepository;
        }

        public ILendingsRepository GetLendingsRepository()
        {
            return _lendingsRepository;
        }

        public async Task Connect(Uri uri)
        {
            try
            {
                connection = await WebSocketClient.Connect(uri, log => { });
                if (connection != null)
                {
                    connection.onMessage = ConnectionMessageHandler;
                }
            }
            catch
            {
                connection = null;
            }
        }

        public void ConnectionMessageHandler(string message)
        {
            context.Post((obj) =>
            {
                onConnectionMessage?.Invoke(message);
            }, null);
        }
    }
}