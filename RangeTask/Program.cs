using Microsoft.VisualBasic;

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
            foreach (Range item in ranges)
            {
                Console.WriteLine($"[{item.From}, {item.To}] равна {item.GetLength()}");
            }

            Console.WriteLine();

            double point = 1.5;
            Console.WriteLine($"Принадлежит точка {point} отрезку?");

            foreach (Range item in ranges)
            {
                Console.WriteLine($"[{item.From}, {item.To}] — {item.IsInside(point)}");
            }

            Console.WriteLine();

            // Часть 2

            Range testRange = new Range(-1, 1);

            Console.WriteLine($"Пересечение отрезка [{testRange.From}, {testRange.To}] с отрезками:");

            foreach (Range item in ranges)
            {
                Console.Write($"[{item.From}, {item.To}] — ");

                Range? intersection = item.GetIntersection(testRange);

                if (intersection == null)
                {
                    Console.WriteLine("пусто");
                }
                else
                {
                    Console.WriteLine($"[{intersection.From}, {intersection.To}]");
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Объединение отрезка [{testRange.From}, {testRange.To}] с отрезками:");

            foreach (Range item in ranges)
            {
                Console.Write($"[{item.From}, {item.To}] — ");

                Range[] union = item.GetUnion(testRange);

                foreach (Range unionPiece in union)
                {
                    Console.Write($"[{unionPiece.From}, {unionPiece.To}] ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Результат вычитания отрезка [{testRange.From}, {testRange.To}] из отрезков:");

            foreach (Range item in ranges)
            {
                Console.Write($"[{item.From}, {item.To}] — ");

                Range[] difference = item.GetDifference(testRange);

                if (difference.Length == 0)
                {
                    Console.WriteLine("пусто");
                }
                else
                {
                    foreach (Range differencePiece in difference)
                    {
                        Console.Write($"[{differencePiece.From}, {differencePiece.To}] ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}