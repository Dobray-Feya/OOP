namespace Arkashova.ShapesTask.Shapes
{
    internal class Triangle : IShape
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public double X3 { get; set; }
        public double Y3 { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(Y1, Y2), Y3) - Math.Min(Math.Min(Y1, Y2), Y3);
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3); ;
        }

        public double GetArea()
        {
            double size1Length = GetSizeLength(X1, Y1, X2, Y2);
            double size2Length = GetSizeLength(X3, Y3, X2, Y2);
            double size3Length = GetSizeLength(X1, Y1, X3, Y3);

            double semiPerimeter = (size1Length + size2Length + size3Length) / 2;

            return Math.Sqrt(semiPerimeter * (semiPerimeter - size1Length) * (semiPerimeter - size2Length) * (semiPerimeter - size3Length));
        }

        public double GetPerimeter()
        {
            double size1Length = GetSizeLength(X1, Y1, X2, Y2);
            double size2Length = GetSizeLength(X3, Y3, X2, Y2);
            double size3Length = GetSizeLength(X1, Y1, X3, Y3);

            return size1Length + size2Length + size3Length;
        }

        public override string ToString()
        {
            return $"Треугольник ({X1}; {Y1}), ({X2}; {Y2}), ({X3}; {Y3})";
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = hash * prime + X1.GetHashCode();
            hash = hash * prime + Y1.GetHashCode();
            hash = hash * prime + X2.GetHashCode();
            hash = hash * prime + Y2.GetHashCode();
            hash = hash * prime + X3.GetHashCode();
            hash = hash * prime + Y3.GetHashCode();

            return hash;
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

            Triangle triangle = (Triangle)obj;

            return triangle.X1 == X1 && triangle.Y1 == Y1 && triangle.X2 == X2 && triangle.Y2 == Y2 && triangle.X3 == X3 && triangle.Y3 == Y3;
        }

        private double GetSizeLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }
    }
}