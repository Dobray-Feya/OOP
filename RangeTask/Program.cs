using System.Runtime.Serialization.Formatters;

namespace RangeTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Часть 1
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

            Console.WriteLine("Длина отрезка:");
            for (int i = 0; i < rangesArray.Length; i++)
            {
                Console.WriteLine($"[{rangesArray[i].From}, {rangesArray[i].To}] равна {rangesArray[i].GetLength()}");
            }

            Console.WriteLine();

            double point = 1.5;
            Console.WriteLine($"Принадлежит точка {point} отрезку?");

            for (int i = 0; i < rangesArray.Length; i++)
            {
                Console.WriteLine($"[{rangesArray[i].From}, {rangesArray[i].To}] — {rangesArray[i].IsInside(point)}");
            }

            // Часть 2
        }
    }
}