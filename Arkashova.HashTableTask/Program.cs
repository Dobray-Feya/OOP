using System.Collections.Generic;

namespace Arkashova.HashTableTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashTable<double?> hashtable1 = new HashTable<double?>(15) { null, 1, 2, 1, null, 6, 2, 3, 4, 5, 6, 7, 9, 10, 5.11, 5.221, 5.301, 5.5, 5.666, 5.7, 5.88888, 5.9 };
            Console.WriteLine(hashtable1);
            Console.WriteLine($"Count = {hashtable1.Count}");
            Console.WriteLine();

            hashtable1.Add(null);
            hashtable1.Add(111111);
            Console.WriteLine("Add(null), Add(111111):");
            Console.WriteLine();
            Console.WriteLine(hashtable1);
            Console.WriteLine($"Count = {hashtable1.Count}");
            Console.WriteLine();

            Console.WriteLine("Remove(null) = " + hashtable1.Remove(null));
            Console.WriteLine("Remove(1) = " + hashtable1.Remove(1));
            Console.WriteLine("Remove(100) = " + hashtable1.Remove(100));
            Console.WriteLine();
            Console.WriteLine(hashtable1);
            Console.WriteLine($"Count = {hashtable1.Count}");
            Console.WriteLine();

            Console.WriteLine("Contains(1) = " + hashtable1.Contains(1));
            Console.WriteLine("Contains(null) = " + hashtable1.Contains(null));
            Console.WriteLine("Contains(-1) = " + hashtable1.Contains(-1));
            Console.WriteLine();

            HashTable<double> hashtable2 = new HashTable<double>(16) { 1, 2, 1, 6, 2, 3, 4, 5, 6, 7, 9, 10, 5.11, 5.221, 5.301, 5.5, 5.666, 5.7, 5.88888, 5.9 };
            Console.WriteLine(hashtable2);
            Console.WriteLine($"Count = {hashtable2.Count}");
            Console.WriteLine();

            Console.WriteLine("Проход по хэш-таблице с помощью foreach:");

            foreach (double item in hashtable2)
            {
                Console.Write(item + " | ");
            }

            Console.WriteLine();
            Console.WriteLine();

            int index = 4;
            const int arrayLength = 28;
            double[] array = new double[arrayLength];
            Console.WriteLine($"Вставить хэш-таблицу в масссив длины {arrayLength}, начиная с позиции {index}:");
            hashtable2.CopyTo(array, index);
            Console.WriteLine(string.Join("| ", array));
            Console.WriteLine();

            hashtable2.Clear();
            Console.WriteLine("Clear():");
            Console.WriteLine(hashtable2);
            Console.WriteLine($"Count = {hashtable2.Count}");
            Console.WriteLine();

            HashTable<double?> hashtable3 = new HashTable<double?>(10) { null, 1, 2, 1, null, 6, 7, 8 };
            Console.WriteLine(hashtable3);
            Console.WriteLine($"Count = {hashtable3.Count}");
            Console.WriteLine();
            double?[] array3 = new double?[15];
            Console.WriteLine($"Вставить хэш-таблицу в масссив длины 15, начиная с позиции 0:");
            hashtable3.CopyTo(array3, 0);
            Console.WriteLine(string.Join("| ", array3));
            Console.WriteLine();

            Console.WriteLine("Проход по хэш-таблице с помощью foreach:");

            foreach (double? item in hashtable3)
            {
                Console.Write(item + " | ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Проход по хэш-таблице с помощью итератора:");

            IEnumerator<double?> iterator = hashtable3.GetEnumerator();

            try
            {
                int iteration = 0;

                while (iterator.MoveNext())
                {
                    if (iteration == 5)
                    {
                        hashtable3.Remove(1);
                    }

                    iteration++;

                    Console.WriteLine(iterator.Current);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}