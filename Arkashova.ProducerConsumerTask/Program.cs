namespace Arkashova.ProducerConsumerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var producerConsumerManager = new ProducerConsumerManager();
            producerConsumerManager.Start();

            Console.WriteLine($"Программа создает потоки производителей и потребителей.");
            Console.WriteLine($"Число производителей - {ProducerConsumerManager.PRODUCERS_COUNT}.");
            Console.WriteLine($"Число потребителей - {ProducerConsumerManager.CONSUMERS_COUNT}.");
            Console.WriteLine();
            Console.WriteLine("Для завершения программы нажмите любую клавишу.");

            Console.ReadKey();
        }
    }
}