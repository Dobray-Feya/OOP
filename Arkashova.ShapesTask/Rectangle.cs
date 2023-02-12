namespace Arkashova.ShapesTask
{
    internal class Rectangle : IShape
    {
        public double Size1 { get; set; }
        public double Size2 { get; set; }

        private double minSize;
        private double maxSize;

        public Rectangle(double size1, double size2)
        {
            Size1 = size1;
            Size2 = size2;

            minSize = Math.Min(size1, size2);
            maxSize = Math.Max(size1, size2);
        }

        public double GetHeight()
        {
            return Size1;
        }

        public double GetWidth()
        {
            return Size2;
        }

        public double GetArea()
        {
            return Size1 * Size2;
        }

        public double GetPerimeter()
        {
            return 2 * (Size1 + Size2);
        }

        public override string ToString()
        {
            return $"прямоуг. {Size1} x {Size2}";
        }

        public override int GetHashCode()
        {
            int prime = 37;

            return prime * (prime + minSize.GetHashCode()) + maxSize.GetHashCode();
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

            Rectangle rectangle = (Rectangle)obj;

            return rectangle.minSize == minSize && rectangle.maxSize == maxSize;
        }
    }
}
