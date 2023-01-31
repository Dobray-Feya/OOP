using Microsoft.VisualBasic;
using System.Runtime.Serialization.Formatters;

namespace RangeTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            double x1 = -5.0;
            double x2 = 0.0;
            double x3 = 3.0;
            double x4 = 5.0;

            Range[] rangesArray =
                { new Range(x1, x2),
                  new Range(x2, x3),
                  new Range(x3, x4),
                  new Range(x2, x4),
                  new Range(x1, x3),
                  new Range(x1, x4) };

            // Часть 1

            Console.WriteLine("Длина отрезка:");
            foreach (Range item in rangesArray)
            {
                Console.WriteLine($"[{item.From}, {item.To}] равна {item.GetLength()}");
            }

            Console.WriteLine();

            double point = 1.5;
            Console.WriteLine($"Принадлежит точка {point} отрезку?");

            foreach (Range item in rangesArray)
            {
                Console.WriteLine($"[{item.From}, {item.To}] — {item.IsInside(point)}");
            }

            Console.WriteLine();

            // Часть 2

            Range range = new Range(1, 4);
            Console.WriteLine($"Пересечение отрезка [{range.From}, {range.To}] с отрезками:");

            foreach (Range item in rangesArray)
            {
                Console.Write($"[{item.From}, {item.To}] — ");

                Range intersection = item.GetIntersectionWith(range);

                if (intersection == null)
                {
                    Console.WriteLine("null");
                }
                else
                {
                    Console.WriteLine($"[{intersection.From}, {intersection.To}]");
                }
            }

            Console.WriteLine();

            Console.WriteLine($"Объединение отрезка [{range.From}, {range.To}] с отрезками:");

            foreach (Range item in rangesArray)
            {
                Console.Write($"[{item.From}, {item.To}] — ");

                Range[] union = item.GetUnionWith(range); 

                foreach (Range unionPiece in union)
                {
                    Console.Write($"[{unionPiece.From}, {unionPiece.To}] ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine($"Результат вычитания отрезка [{range.From}, {range.To}] из отрезков:");

            foreach (Range item in rangesArray)
            {
                Console.Write($"[{item.From}, {item.To}] — ");

                Range[] difference = item.GetDifferenceWith(range);

                foreach (Range differencePiece in difference)
                {
                    Console.Write($"[{differencePiece.From}, {differencePiece.To}] ");
                }

                Console.WriteLine();
            }
        }
    }
}