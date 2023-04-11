namespace Arkashova.ProducerConsumerTask
{
    internal class Consumer
    {
        private readonly ProducerConsumerManager manager;

        private Thread thread;

        public Consumer(ProducerConsumerManager manager, string name)
        {
            this.manager = manager;

            thread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(200);

                    var removedItem = this.manager.RemoveItem();

                    Console.WriteLine($"Thread {thread!.Name} removed item {removedItem}");
                }
            });

            thread.Name = name;
            thread.IsBackground = true;

            thread.Start();
        }
    }
}
