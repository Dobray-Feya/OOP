﻿namespace Arkashova.ArrayListHomeTask
{
    internal class ArrayListHome
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1. Прочитать в список все строки из файла.");
            Console.WriteLine();

            string fileName = "..\\..\\..\\data.txt";
            Console.WriteLine($"Файл: {Path.GetFullPath(fileName)}.");

            List<string> linesList = new List<string>();

            try
            {
                using StreamReader reader = new StreamReader(fileName);

                string? line;

                while ((line = reader.ReadLine()) != null)
                {
                    linesList.Add(line);
                }

                Console.WriteLine();
                Console.WriteLine($"Первая строка в списке: {linesList[0]}");
                Console.WriteLine($"Последняя строка в списке: {linesList[^1]}");
                Console.WriteLine($"Вместимость списка: {linesList.Capacity}");
                Console.WriteLine($"Количество элементов в списке: {linesList.Count}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Не удалось записать строки файла в список.");
                Console.WriteLine("Полное описание ошибки:");
                Console.WriteLine(e);
            }

            Console.WriteLine();
            Console.WriteLine("Задача 2. Есть список из целых чисел. Удалить из него все четные числа. В этой задаче новый список создавать нельзя.");
            Console.WriteLine();

            List<int> numbersList = new List<int> { 0, 1, 2, 3, 4 };
            Console.WriteLine("Исходный список: " + String.Join<int>(" ", numbersList));

            for (int i = 0; i < numbersList.Count; i++)
            {
                if (numbersList[i] % 2 == 0)
                {
                    numbersList.Remove(numbersList[i]);
                }
            }

            Console.WriteLine("Список после удаления четных элементов: " + String.Join<int>(" ", numbersList));

            Console.WriteLine();
            Console.WriteLine("Задача 3. Есть список из целых чисел. Надо создать новый список, в котором будут элементы первого списка в таком же порядке, но без повторений.");
            Console.WriteLine();

            List<int> sourceNumbersList = new List<int> { 0, 1, 0, 2, 0, 1, 3, 2, 4, 5, 5, 0, };
            Console.WriteLine("Исходный список: " + String.Join<int>(" ", sourceNumbersList));

            List<int> withoutDuplicationsNumbersList = new List<int> { sourceNumbersList[0] };

            foreach (int number in sourceNumbersList)
            {
                if (!withoutDuplicationsNumbersList.Contains(number))
                {
                    withoutDuplicationsNumbersList.Add(number);
                }
            }

            Console.WriteLine("Список Без повторяющихся элементов: " + String.Join<int>(" ", withoutDuplicationsNumbersList));
        }
    }
}