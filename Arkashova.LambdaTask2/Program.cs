namespace Arkashova.LambdaTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var roots = GetRoots();

            var squaresCount = GetNumberFromConsole("Введите число корней:", 1);

            Console.WriteLine($"Первые {squaresCount} корней целых чисел:");
            Console.WriteLine(string.Join(", ", roots.Take(squaresCount)));
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
            var i = 0;

            if (i == 0)
            {
                yield return 0;

                i++;
            }

            if (i == 1)
            {
                yield return 1;

                i++;
            }

            var beforePreviousFibonacciNumber = 0;
            var previousFibonacciNumber = 1;

            while (true)
            {
                var fibonacciNumber = beforePreviousFibonacciNumber + previousFibonacciNumber;

                yield return fibonacciNumber;

                i++;

                beforePreviousFibonacciNumber = previousFibonacciNumber;
                previousFibonacciNumber = fibonacciNumber;
            }
        }

        private static int GetNumberFromConsole(string question, int minValue)
        {
            int number;

            while (true)
            {
                Console.WriteLine(question);

                if (!int.TryParse(Console.ReadLine(), out number) || number < minValue)
                {
                    Console.WriteLine($"Введено не верно значение. Значение должно быть целым, большим или равным {minValue}.");
                }
                else
                {
                    return number;
                }
            }
        }
    }
}