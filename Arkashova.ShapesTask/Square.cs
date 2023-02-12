namespace Arkashova.ShapesTask
{
    internal class Square : IShape
    {
        public double Size { get; set; }

        public Square(double size)
        {
            Size = size;
        }

        public double GetHeight()
        {
            return Size;
        }

        public double GetWidth()
        {
            return Size;
        }

        public double GetArea()
        {
            return Size * Size;
        }

        public double GetPerimeter()
        {
            return 4 * Size;
        }

        public override string ToString()
        {
            return $"квадрат {Size} x {Size}";
        }

        public override int GetHashCode()
        {
            return Size.GetHashCode();
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

            return square.Size == Size;
        }
    }
}
