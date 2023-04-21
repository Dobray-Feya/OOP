namespace Arkashova.ThreadsTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Написать программу, которая создает второй поток, который печатает числа от 1 до 10, числа должны печататься раз в секунду
             * При этом основной поток должен напечатать строку «Исполнение продолжено» после того, как завершится созданный поток
             * Код для потока задайте через лямбду */

            Console.WriteLine("Пример 1. Приостановка потока. " +
                              "Первый поток - это поток, в котором запущен Main. Второй поток печатает числа от 1 до 10 раз в секунду. " +
                              "Второй поток приостанавливает выполнение первого потока. Когда второй поток завершается, снова запускается первый поток.");

            var thread1 = new Thread(() =>
             {
                 for (var i = 1; i <= 10; i++)
                 {
                     Console.Write(i + " ");
                     Thread.Sleep(10);
                 }

                 Console.WriteLine();
             });

            Console.WriteLine("Запустить поток, печатающий числа.");
            thread1.Start();

            thread1.Join(); // Здесь изначальный поток (тот, который вызвал поток thread1) остановился и ждет завершения thread1.
            Console.WriteLine("Поток, печатающий числа завершен. Исполнение основного потока продолжено.");

            // Продемонстрируем, как прервать спящий поток.
            // Это справедливо только для потоков в состояниях Sleep, Join, Wait.
            // Здесь посылается команда прерывания потока после того, как пользователь нажал любую клавишу.
            // В задачу, переданную в поток, добавлена обработка исключения ThreadInterruptedException.

            // Вопрос: как прервать поток в другом состоянии (не в Sleep, Join, Wait) - пока не поняла. Методы Suspend Abort устарели и в .NET 5 и выше компиллятор их не разрешает.
            // Возможно, надо использовать токены: https://learn.microsoft.com/ru-ru/dotnet/standard/threading/cancellation-in-managed-threads)

            Console.WriteLine();
            Console.WriteLine("Пример 2. Прерываем спящий поток.");
            Console.WriteLine("Поток печатает числа раз в секунду. Для прерывания потока нажмите любую клавишу.");

            var thread2 = new Thread(() =>
            {
                try
                {
                    for (var i = 1; i <= 100000; i++)
                    {
                        Console.Write(i + " ");
                        Thread.Sleep(1000);
                    }
                }
                catch (ThreadInterruptedException e)
                {
                    Console.WriteLine("Поток прерван.");
                    Console.WriteLine(e.Message);
                }
            });

            thread2.Name = "Printing numbers"; // Это имя можно смотреть в окне потоков (Debug > Windows > Threads)
            thread2.Start();

            Console.ReadKey();
            thread2.Interrupt();
            thread2.Join(); // Основной поток приостановлен, пока поток thread2 не завершится.

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Пример 3. Продемонстрируем race condition - ситуацию, когда потоки имеют доступ к одним и тем же данным, " +
                              "в результате чего программа работает каждый раз по-разному.");
            Console.WriteLine("Два потока не синхронизованно пишут числа от 1 до 100 в один список.");

            var list1 = new List<int>();

            var threadA = new Thread(() =>
            {
                for (var i = 1; i <= 100; i++)
                {
                    list1.Add(i);
                    Thread.Sleep(2); // Пробовала делать без задержки, тогда не получается увидеть рассинхронизацию: сначала один поток все печатает, потом другой.
                }
            });

            var threadB = new Thread(() => // Тут тот же код, что для threadA. По идее надо сделать было массив потоков и общий код для них. Но так мне понятнее.
            {
                for (var i = 1; i <= 100; i++)
                {
                    list1.Add(i);
                    Thread.Sleep(3);
                }
            });

            threadA.Start();
            threadB.Start();

            threadA.Join();  // Здесь приостановлен основной поток. Иначе он следующие две команды раньше времени выводит
            threadB.Join();

            Console.WriteLine("Получился список: " + string.Join(", ", list1));
            Console.WriteLine("В нем элементов: " + list1.Count);

            Console.WriteLine();
            Console.WriteLine("Пример 4. А теперь сделаем такие же потоки, только синхронизуем их.");
            Console.WriteLine("В качестве объекта, по которому синхронизуем возьмем сам список.");

            var list2 = new List<int>();

            var threadC = new Thread(() =>
            {
                for (var i = 1; i <= 100; i++)
                {
                    lock (list2)
                    {
                        list2.Add(i);
                    }

                    Thread.Sleep(2);
                }
            });

            var threadD = new Thread(() =>
            {
                for (var i = 1; i <= 100; i++)
                {
                    lock (list2)
                    {
                        list2.Add(i);
                    }

                    Thread.Sleep(3);
                }
            });

            threadC.Start();
            threadD.Start();

            threadC.Join();
            threadD.Join();

            Console.WriteLine("Получился список: " + string.Join(", ", list2));
            Console.WriteLine("В нем элементов: " + list2.Count);
        }
    }
}