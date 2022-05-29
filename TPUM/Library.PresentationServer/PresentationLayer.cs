using System;
using System.Threading.Tasks;
using Library.LogicServer;

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
            connection.onClose = () => Console.WriteLine("Server: Closing");
            connection.onMessage = ConnectionMessageHandler;

            _connection = connection;
        }

        public void ConnectionMessageHandler(string message)
        {
            Console.WriteLine($"Server: Received message {message}");
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

        }

        public void HandlePersonAdded(PersonInfo person)
        {

        }

        public void HandleLendingAdded(LendingInfo lending)
        {
            SendMessage($"Created Lending: {lending.bookID}, {lending.personID}");
        }

        public void HandleBookRemoved(BookInfo book)
        {

        }

        public void HandlePersonRemoved(PersonInfo person)
        {

        }

        public void HandleLendingRemoved(LendingInfo lending)
        {
            SendMessage($"Removed Lending: {lending.bookID}, {lending.personID}");
        }
    }
}