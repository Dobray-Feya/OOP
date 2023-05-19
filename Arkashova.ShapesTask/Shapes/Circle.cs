namespace Arkashova.ShapesTask.Shapes
{
    internal class Circle : IShape
    {
        public double Radius { get; set; }

        private int secret = 2023; // Сделала приватное поле и метод для того, чтобы попрактиковаться с Reflection (проект AboutReflection).

        public int openField = 2000;

        private void PrintSecret()
        {
            Console.WriteLine("Секрет это: " + secret);
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetHeight()
        {
            return 2 * Radius;
        }

        public double GetWidth()
        {
            return 2 * Radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Круг радиуса {Radius}";
        }

        public override int GetHashCode()
        {
            return Radius.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Circle circle = (Circle)obj;

            return circle.Radius == Radius;
        }
    }
}
