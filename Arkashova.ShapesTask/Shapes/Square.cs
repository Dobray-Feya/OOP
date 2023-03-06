namespace Arkashova.ShapesTask.Shapes
{
    internal class Square : IShape
    {
        public double SideLength { get; set; }

        public Square(double SideLength)
        {
            SideLength = SideLength;
        }

        public double GetHeight()
        {
            return SideLength;
        }

        public double GetWidth()
        {
            return SideLength;
        }

        public double GetArea()
        {
            return SideLength * SideLength;
        }

        public double GetPerimeter()
        {
            return 4 * SideLength;
        }

        public override string ToString()
        {
            return $"Квадрат со стороной длины {SideLength}";
        }

        public override int GetHashCode()
        {
            return SideLength.GetHashCode();
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

            Square square = (Square)obj;

            return square.SideLength == SideLength;
        }
    }
}
