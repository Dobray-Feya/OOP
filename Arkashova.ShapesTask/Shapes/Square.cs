namespace Arkashova.ShapesTask.Shapes
{
    internal class Square : IShape
    {
        public double SizeLength { get; set; }

        public Square(double sizeLength)
        {
            SizeLength = sizeLength;
        }

        public double GetHeight()
        {
            return SizeLength;
        }

        public double GetWidth()
        {
            return SizeLength;
        }

        public double GetArea()
        {
            return SizeLength * SizeLength;
        }

        public double GetPerimeter()
        {
            return 4 * SizeLength;
        }

        public override string ToString()
        {
            return $"Квадрат со стороной длины {SizeLength}";
        }

        public override int GetHashCode()
        {
            return SizeLength.GetHashCode();
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

            return square.SizeLength == SizeLength;
        }
    }
}
