namespace Arkashova.ArayListTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList<int> integersList = new ArrayList<int>();
            Console.WriteLine($"Пустой список: Count -> {integersList.Count}, Capacity -> {integersList.Capacity}");
            integersList.Capacity = 0;
            Console.WriteLine($"Capacity = 0: Count -> {integersList.Count}, Capacity -> {integersList.Capacity}");

            for (int i = 1; i <= 6; i++)
            {
                integersList.Add(i);
                Console.WriteLine($"Add({i}): Count -> {integersList.Count}, Capacity -> {integersList.Capacity}");
            }

            Console.WriteLine(); 
            Console.WriteLine($"Получился список: {integersList}");
            integersList.RemoveAt(1);
            Console.WriteLine($"RemoveAt(1) -> {integersList}");
            Console.WriteLine($"IndexOf(1) = {integersList.IndexOf(1)}");
            Console.WriteLine($"IndexOf(2) = {integersList.IndexOf(2)}");
            Console.WriteLine();

            Console.WriteLine(integersList);
            Console.WriteLine($"Remove(1) = {integersList.Remove(1)} -> {integersList}");
            Console.WriteLine($"Remove(2) = {integersList.Remove(2)} -> {integersList}");
            Console.WriteLine($"Remove(3) = {integersList.Remove(3)} -> {integersList}");
            Console.WriteLine($"Remove(3) = {integersList.Remove(3)} -> {integersList}");
            Console.WriteLine();

            Console.WriteLine($"{integersList} -> Count = {integersList.Count}");
            integersList.Insert(3, 100);
            Console.WriteLine($"Insert(3, 100) -> {integersList} -> Count = {integersList.Count}");
            integersList.Insert(0, 50);
            Console.WriteLine($"Insert(0, 50) -> {integersList} -> Count = {integersList.Count}");
            Console.WriteLine();

            int index2 = 5;
            Console.WriteLine($"Вставить список {integersList} в массив длины 10, начиная с позиции {index2}:");
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
            integersList.Capacity = 12;
            Console.WriteLine("Capacity = 12");
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
            Console.WriteLine($"list[0] = {linesList[0]}");
            Console.WriteLine($"IndexOf(null) = {linesList.IndexOf(null)}");
            Console.WriteLine($"Contains(null) -> {linesList.Contains(null)}");
            Console.WriteLine($"Remove(null) = {linesList.Remove(null)} -> {linesList}");
            Console.WriteLine($"Contains(null) -> {linesList.Contains(null)}");
            Console.WriteLine($"Remove(\"\") = {linesList.Remove(string.Empty)} -> {linesList}");

            linesList.Add(null);
            Console.WriteLine($"Add(null) -> {linesList}");
            linesList.Add("5678");
            Console.WriteLine($"Add(5678) -> {linesList}");
            Console.WriteLine();

            Console.WriteLine($"Вставить список {linesList} в массив длины 10:");
            string[] stringsArray = new string[10];
            linesList.CopyTo(stringsArray, 0);
            Console.WriteLine(string.Join(", ", stringsArray));
            Console.WriteLine();

            Console.WriteLine("Проход по списку с помощью foreach:");

            foreach (string line in linesList)
            {
                if (line is null)
                {
                    Console.Write("{null} | ");
                }
                else
                {
                    Console.Write(line + " | ");
                }
            }
            
            Console.WriteLine();
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
                        linesList.RemoveAt(0);
                    }
                    
                    index++;

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
        }
    }
}