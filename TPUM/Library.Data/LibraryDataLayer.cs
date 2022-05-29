using System;
using System.Collections.Generic;
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
                    await SendMessage("GetPersons");
                    await SendMessage("GetBooks");
                    await SendMessage("GetLendings");
                }
            }
            catch
            {
                connection = null;
            }
        }

        public async Task SendMessage(string message)
        {
            if (connection != null)
            {
                Console.WriteLine($"Server: Sending message {message}");
                await connection.SendAsync(message);
            }
        }

        public void ConnectionMessageHandler(string message)
        {
            context.Post((obj) =>
            {
                ProcessMessage(message);
                onConnectionMessage?.Invoke(message);
            }, null);
        }

        private bool ProcessMessage(string message)
        {
            string[] operands = message.Split(';');

            if (operands.Length < 1)
            {
                return false;
            }

            string op = operands[0];
            switch (op)
            {
                case "AddBook":
                    {
                        if (operands.Length < 6)
                        {
                            return false;
                        }
                        //Guid id = Guid.Parse(operands[1]);
                        //string title = operands[2];
                        //string author = operands[3];
                        //string isbn = operands[4];
                        //bool available = Boolean.Parse(operands[5]);
                        IBook book = BookFromArgs(operands, 1);
                        _booksRepository.AddBook(book);
                        break;
                    }

                case "CreateLending":
                    {
                        if (operands.Length < 3)
                        {
                            return false;
                        }

                        Guid bookID = Guid.Parse(operands[1]);
                        Guid personID = Guid.Parse(operands[2]);
                        _lendingsRepository.AddLending(new Lending(personID, bookID));

                        break;
                    }

                case "RemoveLending":
                    {
                        if (operands.Length < 3)
                        {
                            return false;
                        }

                        Guid bookID = Guid.Parse(operands[1]);
                        Guid personID = Guid.Parse(operands[2]);
                        List<ILending> lendings = _lendingsRepository.FindLendingsByPredicate((lending) =>
                        {
                            return lending.GetBookID() == bookID && lending.GetPersonID() == personID;
                        });
                        if (lendings.Count != 1)
                        {
                            return false;
                        }
                        _lendingsRepository.RemoveLending(lendings[0]);
                        break;
                    }

                case "SendBooks":
                    {
                        if (operands.Length < 2)
                        {
                            return false;
                        }

                        int count = Int32.Parse(operands[1]);
                        for(int idx = 0; idx < count ; ++idx)
                        {
                            int offset = 2 + idx * 5; // 5 arguments to create a Book
                            IBook book = BookFromArgs(operands, offset);
                            _booksRepository.AddBook(book);
                        }
                        break;
                    }

                case "SendPersons":
                {
                    if (operands.Length < 2)
                    {
                        return false;
                    }

                    int count = Int32.Parse(operands[1]);
                    for (int idx = 0; idx < count; ++idx)
                    {
                        int offset = 2 + idx * 3; // 3 arguments to create a Person
                        IPerson person = PersonFromArgs(operands, offset);
                        _personsRepository.AddPerson(person);
                    }
                    break;
                }

                case "SendLendings":
                {
                    if (operands.Length < 2)
                    {
                        return false;
                    }

                    int count = Int32.Parse(operands[1]);
                    for (int idx = 0; idx < count; ++idx)
                    {
                        int offset = 2 + idx * 2; // 2 arguments to create a Lending
                        ILending lending = LendingFromArgs(operands, offset);
                        _lendingsRepository.AddLending(lending);
                    }
                    break;
                }
            }


            return true;
        }

        private IBook BookFromArgs(string[] args, int offset)
        {
            Guid id = Guid.Parse(args[offset]);
            string title = args[offset + 1];
            string author = args[offset + 2];
            string isbn = args[offset + 3];
            bool available = Boolean.Parse(args[offset + 4]);
            return new Book(id, isbn, author, title, available);
        }

        private IPerson PersonFromArgs(string[] args, int offset)
        {
            Guid id = Guid.Parse(args[offset]);
            string name = args[offset + 1];
            string surname = args[offset + 2];
            return new Person(id, name, surname);
        }

        private ILending LendingFromArgs(string[] args, int offset)
        {
            Guid bid = Guid.Parse(args[offset]);
            Guid pid = Guid.Parse(args[offset + 1]);
            return new Lending(pid, bid);
        }

    }
}