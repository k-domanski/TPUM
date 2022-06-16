using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.LogicServer;
using Library.LogicServer.Filters;

namespace Library.PresentationServer
{
    public class PresentationLayer : IPresentationLayer
    {
        private ILibrary _library;
        private WebSocketConnection _connection;

        public PresentationLayer(ILibrary library)
        {
            _library = library;

            _library = LogicServer.Library.CreateDefault();

            _library.onBookAdded += HandleBookAdded;
            _library.onPersonAdded += HandlePersonAdded;
            _library.onLendingAdded += HandleLendingAdded;
            _library.onBookRemoved += HandleBookRemoved;
            _library.onPersonRemoved += HandlePersonRemoved;
            _library.onLendingRemoved += HandleLendingRemoved;

            _library.Initialize();
        }

        public static IPresentationLayer CreateDefault()
        {
            return new PresentationLayer(LogicServer.Library.CreateDefault());
        }

        public async Task RunServer(int port)
        {
            Console.WriteLine("Server: Start");
            await WebSocketServer.Server(port, ServerConnectionHandler);
        }

        internal void ServerConnectionHandler(WebSocketConnection connection)
        {
            Console.WriteLine("Server: Connected");
            connection.onClose = () =>
            {
                Console.WriteLine("Server: Closing");
                _connection = null;
            };
            connection.onMessage = ConnectionMessageHandler;

            _connection = connection;
        }

        public void ConnectionMessageHandler(string message)
        {
            Console.WriteLine($"Server: Received message {message}");
            string[] operands = message.Split(';');
            if (operands.Length < 1)
            {
                return;
            }

            string op = operands[0];
            switch (op)
            {
                case "GetBooks":
                    {
                        List<BookInfo> books = _library.GetBooksManager().GetBooks(new PassFilter<BookInfo>());
                        string response = $"SendBooks;{books.Count}";
                        foreach (BookInfo book in books)
                        {
                            string bookstr = $";{Serializer.SerializeBook(book)}";
                            response += bookstr;
                        }

                        SendMessage(response);
                        break;
                    }

                case "GetPersons":
                    {
                        List<PersonInfo> persons = _library.GetPersonsManager().GetPersons(new PassFilter<PersonInfo>());
                        string response = $"SendPersons;{persons.Count}";
                        foreach (PersonInfo person in persons)
                        {
                            string personstr = $";{Serializer.SerializePerson(person)}";
                            response += personstr;
                        }

                        SendMessage(response);
                        break;
                    }

                case "GetLendings":
                    {
                        List<LendingInfo> lendings =
                            _library.GetLendingsManager().GetLendings(new PassFilter<LendingInfo>());
                        string response = $"SendLendings;{lendings.Count}";
                        foreach (LendingInfo lending in lendings)
                        {
                            string lendingstr = $";{Serializer.SerializeLending(lending)}";
                            response += lendingstr;
                        }

                        SendMessage(response);
                        break;
                    }
            }

        }

        public async Task SendMessage(string message)
        {
            if (_connection != null)
            {
                Console.WriteLine($"Server: Sending message {message}");
                await _connection.SendAsync(message);
            }
        }

        public void HandleBookAdded(BookInfo book)
        {
            SendMessage($"AddBook;{Serializer.SerializeBook(book)}");
        }

        public void HandlePersonAdded(PersonInfo person)
        {

        }

        public void HandleLendingAdded(LendingInfo lending)
        {
            SendMessage($"CreateLending;{Serializer.SerializeLending(lending)}");
        }

        public void HandleBookRemoved(BookInfo book)
        {

        }

        public void HandlePersonRemoved(PersonInfo person)
        {

        }

        public void HandleLendingRemoved(LendingInfo lending)
        {
            SendMessage($"RemoveLending;{Serializer.SerializeLending(lending)}");
        }
    }
}