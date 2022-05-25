using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.PresentationServer
{
    class Program
    {
        private static WebSocketConnection _connection;
        static async Task Main(string[] args)
        {
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

        static void ConnectionMessageHandler(string message)
        {
            Console.WriteLine($"Server: Received message {message}");
        }

        static async Task SendMessage(string message)
        {
            Console.WriteLine($"Server: Sending message {message}");
            await _connection.SendAsync(message);
        }
    }
}
