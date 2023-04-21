using System.Net;
using System.Net.Sockets;

namespace Sokets
{
    internal class EchoServer
    {
        private TcpListener _tcpListener;

        private IPAddress _hostIp;
        private int _port;

        public EchoServer(IPAddress hostIp, int port)
        {
            _hostIp = hostIp;
            _port = port;

            _tcpListener = new TcpListener(_hostIp, _port);

            _tcpListener.Start();
        }

        public void Run()
        {
            while (true)
            {
                var tcpClient = _tcpListener.AcceptTcpClient(); // Метод AcceptTcpClient() блокирует текущий поток, пока клиент не подсоединится к серверу

                var thread = new Thread(new EchoServerClient(tcpClient).Run);

                thread.Start();

                Console.WriteLine("The client has joined the server.");

                var stream = tcpClient.GetStream();

                using (var reader = new StreamReader(stream))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        var line = reader.ReadLine();
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}

