namespace Arkashova.LambdaTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var roots = GetRoots();

            var rootsCount = GetNumberFromConsole("Введите число корней:", 1);

            Console.WriteLine($"Первые {rootsCount} корней целых чисел:");
            Console.WriteLine(string.Join(", ", roots.Take(rootsCount)));
            Console.WriteLine();

            var fibonacciNumbers = GetFibonacciNumbers();

            var fibonacciNumbersCount = GetNumberFromConsole("Введите количество чисел Фибоначчи:", 1);

            Console.WriteLine($"Первые {fibonacciNumbersCount} чисел Фибоначчи:");
            Console.WriteLine(string.Join(", ", fibonacciNumbers.Take(fibonacciNumbersCount)));
        }

        private static IEnumerable<double> GetRoots()
        {
            var i = 0;

            while (true)
            {
                yield return Math.Sqrt(i);

                i++;
            }
        }

        private static IEnumerable<int> GetFibonacciNumbers()
        {
            yield return 0;

            yield return 1;

            var beforePreviousFibonacciNumber = 0;
            var previousFibonacciNumber = 1;

            while (true)
            {
                var fibonacciNumber = beforePreviousFibonacciNumber + previousFibonacciNumber;

                yield return fibonacciNumber;

                beforePreviousFibonacciNumber = previousFibonacciNumber;
                previousFibonacciNumber = fibonacciNumber;
            }
        }

        private static int GetNumberFromConsole(string question, int minValue)
        {
            while (true)
            {
                Console.WriteLine(question);

                if (int.TryParse(Console.ReadLine(), out int number) && number >= minValue)
                {
                    return number;
                }

                Console.WriteLine($"Введено неверное значение. Значение должно быть целым числом, большим или равным {minValue}.");
            }
        }
    }
}