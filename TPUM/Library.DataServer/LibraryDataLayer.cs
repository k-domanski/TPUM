using Library.DataServer.Interface;

namespace Library.DataServer
{
    public class LibraryDataLayer : ILibraryDataLayer
    {
        private IBooksRepository _booksRepository;
        private IPersonsRepository _personsRepository;
        private ILendingsRepository _lendingsRepository;

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
    }
}