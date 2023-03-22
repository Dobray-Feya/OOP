namespace Arkashova.LambdaTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var squares = GetSquares();

            int squaresCount = GetNumberFromConsole("Введите число корней:", 1);

            Console.WriteLine($"Первые {squaresCount} корней целых чисел:");
            Console.WriteLine(string.Join(", ", squares.Skip(1).Take(squaresCount).ToList()));
            Console.WriteLine();

            var fibonacciNumbers = GetFibonacciNumbers();

            int fibonacciNumbersCount = GetNumberFromConsole("Введите количество чисел Фибоначчи:", 1);

            Console.WriteLine($"Первые {fibonacciNumbersCount} чисел Фибоначчи:"); 
            Console.WriteLine(string.Join(", ", fibonacciNumbers.Take(fibonacciNumbersCount).ToList()));
        }

        private static IEnumerable<int> GetSquares()
        {
            int i = 0;

            while (true)
            {
                yield return i * i;

                i++;
            }
        }

        private static IEnumerable<int> GetFibonacciNumbers()
        {
            int i = 0;

            while (true)
            {
                yield return GetFibonacciNumberByIndex(i);

                i++;
            }
        }

        private static int GetFibonacciNumberByIndex(int index)
        {
            if (index == 0)
            {
                return 0;
            }

            if (index == 1)
            {
                return 1;
            }
            
            int fibonacciNumber = 1;

            int previousFibonacciNumber = 0;

            for (int i = 2; i <= index; i++)
            {
                int nextFibonacciNumber = previousFibonacciNumber + fibonacciNumber;
                previousFibonacciNumber = fibonacciNumber;
                fibonacciNumber = nextFibonacciNumber;
            }

            return fibonacciNumber;
        }

        private static int GetNumberFromConsole(string question, int minValue)
        {
            int number;

            do
            {
                Console.WriteLine(question);
            }

            while (!int.TryParse(Console.ReadLine(), out number) || number < minValue);

            return number;
        }
    }
}