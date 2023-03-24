﻿namespace Arkashova.ArayListTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            ArrayList<int> integersList = new ArrayList<int> { 1, 2, 1, 3, 3, 4, 5 };

            Console.WriteLine("Исходный список: " + integersList);
            Console.WriteLine();

            integersList.RemoveAt(1);
            Console.WriteLine("RemoveAt(1) -> " + integersList);
            Console.WriteLine();

            Console.WriteLine("IndexOf(1) = " + integersList.IndexOf(1));
            Console.WriteLine("IndexOf(2) = " + integersList.IndexOf(2));
            Console.WriteLine();

            Console.WriteLine(integersList);
            Console.WriteLine("Remove(1) = " + integersList.Remove(1) + " -> " + integersList);
            Console.WriteLine("Remove(2) = " + integersList.Remove(2) + " -> " + integersList);
            Console.WriteLine("Remove(3) = " + integersList.Remove(3) + " -> " + integersList);
            Console.WriteLine("Remove(3) = " + integersList.Remove(3) + " -> " + integersList);
            Console.WriteLine();

            Console.WriteLine(integersList + " Count = " + integersList.Count);
            int index1 = 3;
            integersList.Insert(index1, 100);
            Console.WriteLine($"Insert({index1}, 100) -> " + integersList + " -> Count = " + integersList.Count);
            integersList.Insert(0, 50);
            Console.WriteLine($"Insert(0, 50) -> " + integersList + " -> Count = " + integersList.Count);
            Console.WriteLine();

            int index2 = 5;
            Console.WriteLine($"Вставить список {integersList} в масссив длины 10, начиная с позиции {index2}:");
            int[] array = new int[10];
            integersList.CopyTo(array, index2);
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine();

            integersList.Add(101);
            integersList.Add(102);
            integersList.Add(103);
            integersList.Add(104);
            integersList.Add(105);

            Console.WriteLine($"{integersList}: Count = {integersList.Count}, Capacity = {integersList.Capacity}");
            integersList.Capacity = 10;
            Console.WriteLine("Capacity = 10");
            integersList.TrimExcess();
            Console.WriteLine($"TrimExcess() -> Count = {integersList.Count}, Capacity = {integersList.Capacity}");

            integersList.Capacity = 11;
            Console.WriteLine("Capacity = 11");
            integersList.TrimExcess();
            Console.WriteLine($"TrimExcess() -> Count = {integersList.Count}, Capacity = {integersList.Capacity}");
            Console.WriteLine();

            Console.WriteLine($"{integersList} -> Count = {integersList.Count}");
            integersList.Clear();
            Console.WriteLine($"Clear() -> {integersList} -> Count = {integersList.Count}");
            Console.WriteLine();

            ArrayList<string> linesList = new ArrayList<string> { null, "hello", "hello", "1234", "" };
            Console.WriteLine(linesList);
            Console.WriteLine("list[0] = " + linesList[0]);
            Console.WriteLine("IndexOf(null) = " + linesList.IndexOf(null));
            Console.WriteLine("Contains(null) -> " + linesList.Contains(null));
            Console.WriteLine("Remove(null) = " + linesList.Remove(null) + " -> " + linesList);
            Console.WriteLine("Contains(null) -> " + linesList.Contains(null));
            Console.WriteLine("Remove(\"\") = " + linesList.Remove(string.Empty) + " -> " + linesList);

            linesList.Add(null);
            Console.WriteLine("Add(null) -> " + linesList);
            linesList.Add("5678");
            Console.WriteLine("Add(5678) -> " + linesList);
            Console.WriteLine();

            Console.WriteLine($"Вставить список {linesList} в масссив длины 10:");
            string[] stringsArray = new string[10];
            linesList.CopyTo(stringsArray, 0);
            Console.WriteLine(string.Join(", ", stringsArray));
            Console.WriteLine();

            ArrayList<string> linesList2 = new ArrayList<string>();
            linesList2.Add("one");
            Console.WriteLine(linesList2 + " Count = " + linesList2.Count + " Capacity = " + linesList2.Capacity);
            Console.WriteLine();

            Console.WriteLine("Проход по списку с помощью foreach:");

            foreach (string line in linesList)
            {
                Console.WriteLine(line);
            }
            
            Console.WriteLine();
            Console.WriteLine("Проход по списку с помощью итератора:");

            IEnumerator<string> iterator = linesList.GetEnumerator();

            try
            {
                int index = 0;

                while (iterator.MoveNext())
                {
                    if (index == 2)
                    {
                        linesList.Remove("0");
                    }
                    
                    index++;

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