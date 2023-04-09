namespace Arkashova.HashTableTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashTable<double?> hashTable1 = new HashTable<double?>(15) { null, 1, 2, 1, null, 6, 2, 3, 4, 5, 6, 7, 9, 10, 5.11, 5.221, 5.301, 5.5, 5.666, 5.7, 5.88888, 5.9 };
            Console.WriteLine(hashTable1);
            Console.WriteLine($"Count = {hashTable1.Count}");
            Console.WriteLine();

            hashTable1.Add(null);
            hashTable1.Add(111111);
            Console.WriteLine("Add(null), Add(111111):");
            Console.WriteLine();
            Console.WriteLine(hashTable1);
            Console.WriteLine($"Count = {hashTable1.Count}");
            Console.WriteLine();

            Console.WriteLine("Remove(null) = " + hashTable1.Remove(null));
            Console.WriteLine("Remove(1) = " + hashTable1.Remove(1));
            Console.WriteLine("Remove(100) = " + hashTable1.Remove(100));
            Console.WriteLine();
            Console.WriteLine(hashTable1);
            Console.WriteLine($"Count = {hashTable1.Count}");
            Console.WriteLine();

            Console.WriteLine("Contains(1) = " + hashTable1.Contains(1));
            Console.WriteLine("Contains(null) = " + hashTable1.Contains(null));
            Console.WriteLine("Contains(-1) = " + hashTable1.Contains(-1));
            Console.WriteLine();

            HashTable<double> hashTable2 = new HashTable<double>() { 1, 2, 1, 6, 2, 3, 4, 5, 6, 7, 9, 10, 5.11, 5.221, 5.301, 5.5, 5.666, 5.7, 5.88888, 5.9 };
            Console.WriteLine(hashTable2);
            Console.WriteLine($"Count = {hashTable2.Count}");
            Console.WriteLine();

            Console.WriteLine("Проход по хэш-таблице с помощью foreach:");

            foreach (double item in hashTable2)
            {
                Console.Write(item + " | ");
            }

            Console.WriteLine();
            Console.WriteLine();

            int index = 4;
            const int arrayLength = 28;
            double[] array = new double[arrayLength];
            Console.WriteLine($"Вставить хэш-таблицу в массив длины {arrayLength}, начиная с позиции {index}:");
            hashTable2.CopyTo(array, index);
            Console.WriteLine(string.Join("| ", array));
            Console.WriteLine();

            hashTable2.Clear();
            Console.WriteLine("Clear():");
            Console.WriteLine(hashTable2);
            Console.WriteLine($"Count = {hashTable2.Count}");
            Console.WriteLine();

            HashTable<double?> hashTable3 = new HashTable<double?>(5) { null, 1, 2, 1, null, 6, 7, 9, 10, 11, 12 };
            Console.WriteLine(hashTable3);
            Console.WriteLine($"Count = {hashTable3.Count}");
            Console.WriteLine();

            Console.WriteLine($"Remove(13) -> {hashTable3.Remove(13)}");
            Console.WriteLine(hashTable3);
            Console.WriteLine();

            double?[] array3 = new double?[15];
            Console.WriteLine("Вставить хэш-таблицу в массив длины 15, начиная с позиции 0:");
            hashTable3.CopyTo(array3, 0);
            Console.WriteLine(string.Join("| ", array3));
            Console.WriteLine();

            Console.WriteLine("Проход по хэш-таблице с помощью foreach:");

            foreach (double? item in hashTable3)
            {
                if (item is null)
                {
                    Console.Write("{null} | ");
                }
                else
                {
                    Console.Write(item + " | ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Проход по хэш-таблице с помощью итератора:");

            IEnumerator<double?> iterator = hashTable3.GetEnumerator();

            try
            {
                int iteration = 0;

                while (iterator.MoveNext())
                {
                    if (iteration == 5)
                    {
                        hashTable3.Remove(1);
                    }

                    iteration++;

                    if (iterator.Current is null)
                    {
                        Console.Write("{null} | ");
                    }
                    else
                    {
                        Console.Write(iterator.Current + " | ");
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            HashTable<string?> hashTable4 = new HashTable<string?>(4) { null, "null", "zero" };
            Console.WriteLine(hashTable4);
        }
    }
}