namespace Arkashova.ProducerConsumerTask
{
    internal class Producer
    {
        private readonly ProducerConsumerManager manager;

        private Thread thread;

        public Producer(ProducerConsumerManager manager, string name)
        {
            this.manager = manager;

            thread = new Thread(() =>
            {
                var i = 0;

                while (true)
                {
                    Thread.Sleep(200); // Имитация работы

                    this.manager.AddItem(i);

                    Console.WriteLine($"Thread {thread!.Name} added item {i}.");

                    i++;
                }
            });

            thread.Name = name;
            thread.IsBackground = true; // Сделала поток фоновым (и для потребителей), чтобы приложение завершалось, когда завершится поток с Main

            thread.Start();
        }
    }
}
