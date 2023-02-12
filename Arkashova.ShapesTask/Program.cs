namespace Arkashova.ShapesTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapes =
            {
                new Square(5),
                new Square(6),
                new Triangle(-1.1, 0, 1.1, 0, 0, 2.1),
                new Triangle(1, 0, 2, 0, 5, 0),
                new Rectangle(1, 10),
                new Rectangle(10, 1),
                new Rectangle(5, 5),
                new Rectangle(5.5, 0.08),
                new Circle(1),
                new Circle(1.0001)
            };

            Console.WriteLine($"{"фигура",-34} {"площадь",10} {"периметр",11} {"высота",10} {"ширина",10} {"хэш",10}");

            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine($"{shapes[i],-35} {shapes[i].GetArea(),10:f3} {shapes[i].GetPerimeter(),10:f3} {shapes[i].GetHeight(),10:f3} {shapes[i].GetWidth(),10:f3} {shapes[i].GetHashCode(),15:f3}");
            }

            Console.WriteLine();

            IShape shape1 = GetShapeWithMaxArea(shapes);
            Console.WriteLine($"Фигура с максимальной площадью: {shape1} ({shape1.GetArea()}).");
            Console.WriteLine();

            IShape shape2 = GetShapeWithSecondPerimeter(shapes);
            Console.WriteLine($"Фигура со вторым по величине периметром: {shape2} ({shape2.GetPerimeter()}).");
            Console.WriteLine();
        }

        public static IShape GetShapeWithMaxArea(IShape[] shapes)
        {
            // Вспомогательный массив, чтобы не менять сортировку исходного массива
            IShape[] temp = new IShape[shapes.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = shapes[i];
            }

            Array.Sort(temp, new AreaComparer());

            return temp[temp.Length - 1];
        }

        public static IShape GetShapeWithSecondPerimeter(IShape[] shapes)
        {
            // Вспомогательный массив, чтобы не менять сортировку исходного массива
            IShape[] temp = new IShape[shapes.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = shapes[i];
            }

            Array.Sort(temp, new PerimeterComparer());

            return temp[temp.Length - 2];
        }
    }
}