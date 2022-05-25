using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.PresentationServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Server: Start");
            await WebSocketServer.Server(8080, ServerConnectionHandler);
        }

        static void ServerConnectionHandler(WebSocketConnection connection)
        {

        }
    }
}
