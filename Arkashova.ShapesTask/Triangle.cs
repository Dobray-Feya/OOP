namespace Arkashova.ShapesTask
{
    internal class Triangle : IShape
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public double X3 { get; set; }
        public double Y3 { get; set; }

        private double minSize;
        private double middleSize;
        private double maxSize;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;

            double size1 = Math.Sqrt((X1 - X2) * (X1 - X2) + (Y1 - Y2) * (Y1 - Y2));
            double size2 = Math.Sqrt((X1 - X3) * (X1 - X3) + (Y1 - Y3) * (Y1 - Y3));
            double size3 = Math.Sqrt((X2 - X3) * (X2 - X3) + (Y2 - Y3) * (Y2 - Y3));

            double[] temp = new double[] { size1, size2, size3 };
            Array.Sort(temp);

            minSize = temp[0];
            middleSize = temp[1];
            maxSize = temp[2];
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
            double semiperimeter = GetPerimeter() / 2;

            return Math.Sqrt(semiperimeter * (semiperimeter - minSize) * (semiperimeter - middleSize) * (semiperimeter - maxSize)); ;
        }

        public double GetPerimeter()
        {
            return minSize + middleSize + maxSize;
        }

        public override string ToString()
        {
            return $"треуг. ({X1}; {Y1}) ({X2}; {Y2}), ({X3}; {Y3})";
        }

        public override int GetHashCode()
        {
            int prime = 37;
            
            return prime * (prime * (prime + minSize.GetHashCode()) + middleSize.GetHashCode()) + maxSize.GetHashCode();
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

            return (triangle.minSize == minSize) && (triangle.middleSize == middleSize) && (triangle.maxSize == maxSize);
        }
    }
}