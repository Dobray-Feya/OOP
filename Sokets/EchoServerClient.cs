using System.Net.Sockets;

namespace Sokets
{
    internal class EchoServerClient
    {
        private TcpClient _tcpClient;

        public EchoServerClient(TcpClient tcpClient)
        {
            _tcpClient = tcpClient;
        }

        public void Run()
        {
            Console.WriteLine("EchoServerClient start.");
        }
    }
}
