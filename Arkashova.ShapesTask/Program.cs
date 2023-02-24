using Arkashova.ShapesTask.Shapes;
using Arkashova.ShapesTask.Comparers;

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

            Console.WriteLine($"{"фигура",-41} {"площадь",10} {"периметр",11} {"высота",10} {"ширина",10} {"хэш",10}");

            foreach (IShape shape in shapes)
            {
                Console.WriteLine($"{shape,-42} {shape.GetArea(),10:f3} {shape.GetPerimeter(),10:f3} {shape.GetHeight(),10:f3} {shape.GetWidth(),10:f3} {shape.GetHashCode(),15:f3}");
            }

            Console.WriteLine();

            IShape shapeWithMaxArea = GetShapeWithMaxArea(shapes);
            Console.WriteLine($"Фигура с максимальной площадью: {shapeWithMaxArea} ({shapeWithMaxArea.GetArea()}).");
            Console.WriteLine();

            IShape shapeWithSecondPerimeter = GetShapeWithSecondPerimeter(shapes);
            Console.WriteLine($"Фигура со вторым по величине периметром: {shapeWithSecondPerimeter} ({shapeWithSecondPerimeter.GetPerimeter()}).");
            Console.WriteLine();
        }

        public static IShape GetShapeWithMaxArea(IShape[] shapes)
        {
            IShape[] sortedShapes = new IShape[shapes.Length];
            shapes.CopyTo(sortedShapes, 0);

            Array.Sort(sortedShapes, new AreaComparer());

            return sortedShapes[^1];
        }

        public static IShape GetShapeWithSecondPerimeter(IShape[] shapes)
        {
            IShape[] sortedShapes = new IShape[shapes.Length];
            shapes.CopyTo(sortedShapes, 0);

            Array.Sort(sortedShapes, new PerimeterComparer());

            return sortedShapes[^2];
        }
    }
}