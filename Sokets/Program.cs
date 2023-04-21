using System.Net;

namespace Sokets
{
    internal class Program
    {
        private static int _port = 2000;
        private static IPAddress _hostIp = IPAddress.Parse("127.0.0.1");

        static void Main(string[] args)
        {
            
            Console.WriteLine("The program demonstrates sockets.");
            Console.WriteLine();

            var server = new EchoServer(_hostIp, _port);
            var serverThread = new Thread(server.Run);
            serverThread.Start();

            var client1 = new EchoClient(_hostIp, _port, "111");
            var thread1 = new Thread(client1.Run);
            thread1.Start();

            var client2 = new EchoClient(_hostIp, _port, "222");
            var thread2 = new Thread(client2.Run);
            thread2.Start();
        }
    }
}