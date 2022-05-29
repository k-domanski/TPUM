using System.Threading.Tasks;
using Library.LogicServer;

namespace Library.PresentationServer
{
    public interface IPresentationLayer
    {
        Task RunServer(int port);
        void ConnectionMessageHandler(string message);
        Task SendMessage(string message);
    }
}