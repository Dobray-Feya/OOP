namespace Range
{
    public class Program
    {
        static void Main(string[] args)
        {
            double x11 = 300;
            double x12 = -100;

            double x21 = 300;
            double x22 = 200;

            Range range1 = new Range(x11, x12);
            Range range2 = new Range(x21, x22);

            Console.WriteLine($"Длина отрезка 1 равна {range1.GetLength()}.");
            Console.WriteLine($"Длина отрезка 2 равна {range2.GetLength()}.");

            if (range1.IsInside(range2.From) && range1.IsInside(range2.To))
            {
                Console.WriteLine("Отрезок 2 лежит внутри отрезка 1.");
            }
            else if (range2.IsInside(range1.From) && range2.IsInside(range1.To))
            {
                Console.WriteLine("Отрезок 1 лежит внутри отрезка 2.");
            }
            else if (range2.IsInside(range1.From) || range2.IsInside(range1.To))
            {
                Console.WriteLine("Отрезки пересекаются");
            }
            else
            {
                Console.WriteLine("Отрезки не пересекаются");
            }
        }
    }
}