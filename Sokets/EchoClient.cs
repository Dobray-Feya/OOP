using System.Net;
using System.Net.Sockets;

namespace Sokets
{
    internal class EchoClient
    {
        private TcpClient _tcpClient;

        private string _input;

        public EchoClient(IPAddress ip, int port, string input)
        {
            _tcpClient = new TcpClient(ip.ToString(), port);
            _input = input;
        }

        public EchoClient(int port, string input)
        {
            _tcpClient = new TcpClient("127.0.0.1", port);
            _input = input;
        }

        public void Run()
        {
            using (_tcpClient)
            {
                var stream = _tcpClient.GetStream();

                using (var reader = new StreamReader(stream))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.WriteLine(_input);
                        writer.Flush();

                        string line = reader.ReadLine();
                        Console.WriteLine("Received from Server: " + line);
                    }
                }
            }
        }
    }
}
