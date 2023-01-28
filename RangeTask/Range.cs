namespace Range
{
    internal class Range
    {
        // это автосвойства объекта
        public double From { get; set; }

        public double To { get; set; }

        // это конструктор для инициализации объекта
        public Range(double from, double to)
        {
            if (from < to)
            {
                From = from;
                To = to;
            }
            else
            {
                From = to;
                To = from;
            }
        }

        // это методы объекта
        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return From <= number && number <= To;
        }
    }
}
