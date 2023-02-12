namespace Arkashova.ShapesTask
{
    internal class Circle : IShape
    {
        public double Radius { get; set; }

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
            return $"круг радиуса {Radius}";
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
