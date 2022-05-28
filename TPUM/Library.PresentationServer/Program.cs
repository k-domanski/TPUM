using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.LogicServer;
using Library.LogicServer.Filters;

namespace Library.PresentationServer
{
    class Program
    {
        private static ILibrary _library;

        private static WebSocketConnection _connection;
        static async Task Main(string[] args)
        {
            _library = LogicServer.Library.CreateDefault();

            _library.onBookAdded += HandleBookAdded;
            _library.onPersonAdded += HandlePersonAdded;
            _library.onLendingAdded += HandleLendingAdded;
            _library.onBookRemoved += HandleBookRemoved;
            _library.onPersonRemoved += HandlePersonRemoved;
            _library.onLendingRemoved += HandleLendingRemoved;

            _library.Initialize();

            // Sanity  check
            //List<BookInfo> books = _library.GetBooksManager().GetBooks(new PassFilter<BookInfo>());
            //foreach (var book in books)
            //{
            //    Console.WriteLine(book.title);
            //}

            Console.WriteLine("Server: Start");
            await WebSocketServer.Server(8081, ServerConnectionHandler);
        }

        static void ServerConnectionHandler(WebSocketConnection connection)
        {
            Console.WriteLine("Server: Connected");
            connection.onClose = () => Console.WriteLine("Server: Closing");
            connection.onMessage = ConnectionMessageHandler;

            _connection = connection;
        }

        static void TrySendMessage(string message)
        {
            if (_connection != null)
            {
                _connection.SendAsync(message);
            }
        }

        static void ConnectionMessageHandler(string message)
        {
            Console.WriteLine($"Server: Received message {message}");
        }

        static async Task SendMessage(string message)
        {
            Console.WriteLine($"Server: Sending message {message}");
            await _connection.SendAsync(message);
        }

        static void HandleBookAdded(BookInfo book)
        {

        }

        static void HandlePersonAdded(PersonInfo person)
        {

        }

        static void HandleLendingAdded(LendingInfo lending)
        {
            Console.WriteLine($"Created Lending: {lending.bookID}, {lending.personID}");
            TrySendMessage("CreatedLending");
        }

        static void HandleBookRemoved(BookInfo book)
        {

        }

        static void HandlePersonRemoved(PersonInfo person)
        {

        }

        static void HandleLendingRemoved(LendingInfo lending)
        {
            Console.WriteLine($"Removed Lending: {lending.bookID}, {lending.personID}");
            TrySendMessage("RemovedLending");
        }
    }
}
