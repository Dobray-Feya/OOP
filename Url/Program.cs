using System.Net;

namespace Url
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Работа с классом Uri.");
            Console.WriteLine();

            var uri2Gis = new Uri("https://2gis.ru");

            Console.WriteLine(uri2Gis.ToString());

            var uri2GisNsk = new Uri(uri2Gis, "novosibirsk");
            var uri2GisMoscow = new Uri(uri2Gis, "moscow");

            Console.WriteLine(uri2GisNsk.ToString());
            Console.WriteLine(uri2GisMoscow.ToString());

            var searchUri2GisMoscow = new Uri(uri2GisMoscow, "search/%D0%BF%D0%BE%D0%B5%D1%81%D1%82%D1%8C/firm/4504127908391014/37.621026%2C55.754423?floor=0&m=37.619767%2C55.754321%2F17.92");

            Console.WriteLine("Поисковый запрос:" + searchUri2GisMoscow.ToString());
            Console.WriteLine("protocol = " + searchUri2GisMoscow.Scheme);
            Console.WriteLine("authority = " + searchUri2GisMoscow.Authority);
            Console.WriteLine("host = " + searchUri2GisMoscow.Host);
            Console.WriteLine("port = " + searchUri2GisMoscow.Port);
            Console.WriteLine("path = " + searchUri2GisMoscow.AbsolutePath);
            Console.WriteLine("query = " + searchUri2GisMoscow.Query);
            Console.WriteLine("ref = " + searchUri2GisMoscow.Fragment);

            Console.Write("IP: ");
            var hostInfo = Dns.GetHostEntry(searchUri2GisMoscow.Host.ToString());

            foreach (var ip in hostInfo.AddressList)
            {
                Console.WriteLine(ip.ToString());
            }

            Console.WriteLine(); 
            Console.Write($"Получить содержимое HTML-страницы по адресу {uri2GisNsk}: ");

            using (var client = new WebClient()) // класс устарел. Нужно использовать HttpClient
            {
                var text = client.DownloadString(uri2GisNsk);
                Console.WriteLine(text);
            }
        }
    }
}