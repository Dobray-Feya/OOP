namespace Arkashova.RangeTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            double x1 = -5.0;
            double x2 = 0.0;
            double x3 = 3.0;
            double x4 = 5.0;
            double x5 = 10.0;

            Range[] ranges =
            {
                new Range(x1, x2),
                new Range(x2, x3),
                new Range(x3, x4),
                new Range(x2, x4),
                new Range(x1, x4),
                new Range(x2, x5)
            };

            // Часть 1

            Console.WriteLine("Длина отрезка:");

            foreach (Range range in ranges)
            {
                Console.WriteLine($"{range} равна {range.GetLength()}");
            }

            double point = 1.5;
            Console.WriteLine();
            Console.WriteLine($"Принадлежит точка {point} отрезку?");

            foreach (Range range in ranges)
            {
                Console.WriteLine($"{range} — {range.IsInside(point)}");
            }

            Console.WriteLine();

            // Часть 2

            Range testRange = new Range(-1, 1);
            Console.WriteLine($"Пересечение отрезка {testRange} с отрезками:");

            foreach (Range range in ranges)
            {
                Console.Write($"{range} — ");

                Range? intersection = range.GetIntersection(testRange);

                if (intersection == null)
                {
                    Console.WriteLine("пусто");
                }
                else
                {
                    Console.WriteLine($"{intersection}");
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Объединение отрезка {testRange} с отрезками:");

            foreach (Range range in ranges)
            {
                Console.Write($"{range} — ");

                Range[] union = range.GetUnion(testRange);

                foreach (Range unionPiece in union)
                {
                    Console.Write($"{unionPiece} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Результат вычитания отрезка {testRange} из отрезков:");

            foreach (Range range in ranges)
            {
                Console.Write($"{range} — ");

                Range[] difference = range.GetDifference(testRange);

                if (difference.Length == 0)
                {
                    Console.WriteLine("пусто");
                }
                else
                {
                    foreach (Range differencePiece in difference)
                    {
                        Console.Write($"{differencePiece} ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}