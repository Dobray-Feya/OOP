namespace Arkashova.ProducerConsumerTask
{
    public class ProducerConsumerManager // Наверно можно было бы производителей и потебитеоей поместить в список, чтобы потом можно было к ним обращаться, например, для прерывания.
                                         // Тогда в классах Производителя и Потребителя можно было бы сделать try-catch для обработки прерывания.
                                         // В этой программе сделала производителей и потребителей фоновыми потоками, чтобы программа завершалась только по завершенияю потока для Main.
    {
        private readonly List<int> list = new List<int>();

        private readonly object lockObj = new object();

        private const int CAPACITY = 10;

        public const int PRODUCERS_COUNT = 3;

        public const int CONSUMERS_COUNT = 3;

        public ProducerConsumerManager() { }

        public void Start()
        {
            for (var i = 1; i <= PRODUCERS_COUNT; i++)
            {
                var producer = new Producer(this, "producer" + i.ToString());
            }

            for (var i = 1; i <= CONSUMERS_COUNT; i++)
            {
                var consumer = new Consumer(this, "consumer" + i.ToString());
            }
        }

        public void AddItem(int item)
        {
            lock(lockObj)
            {
                while (list.Count >= CAPACITY)
                {
                    Monitor.Wait(lockObj);
                }

                list.Add(item);

                Console.WriteLine(string.Join(", ", list));

                Monitor.PulseAll(lockObj);
            }
        }

        public int RemoveItem() // Переименовала GetItem в RemoveItem, чтобы было ясно, что элемент удаляется
        {
            lock (lockObj)
            {
                while (list.Count <= 0)
                {
                    Monitor.Wait(lockObj);
                }

                int result = list[0]; // Удаляю первый элемент списка, а не последний. Иначе первые элементы никогда не удалятся, если потребители работают медленнее, чем производители

                list.RemoveAt(0);

                Console.WriteLine(string.Join(", ", list));

                Monitor.PulseAll(lockObj);

                return result;
            }
        }
    }
}
