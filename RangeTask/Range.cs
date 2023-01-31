namespace RangeTask
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

        public Range GetIntersectionWith(Range anotherRange)
        {
            if (this.IsInside(anotherRange.From))
            {
                return new Range(anotherRange.From, Math.Min(this.To, anotherRange.To));
            }

            if (anotherRange.IsInside(this.From))
            {
                return new Range(this.From, Math.Min(this.To, anotherRange.To));
            }

            return null;
        }

        public Range[] GetUnionWith(Range anotherRange)
        {
            if (this.IsInside(anotherRange.From) || anotherRange.IsInside(this.From))
            {
                return new Range[] { new Range(Math.Min(this.From, anotherRange.From), Math.Max(this.To, anotherRange.To)) };
            }

            return new Range[] { this, anotherRange };
        }

        public Range[] GetDifferenceWith(Range anotherRange)
        {
            if ((anotherRange.From <= this.From) && (anotherRange.To >= this.To))
            {
                return null;
            }

            if ((anotherRange.From >= this.To) || (anotherRange.To <= this.From))
            {
                return new Range[] { this };
            }

            if ((anotherRange.From <= this.From) && (this.IsInside(anotherRange.To)))
            {
                return new Range[] { new Range(anotherRange.To, this.To) };
            }

            if ((anotherRange.To >= this.To) && (this.IsInside(anotherRange.From)))
            {
                return new Range[] { new Range(this.From, anotherRange.From) };
            }

            return new Range[] { new Range(this.From, anotherRange.From), new Range(anotherRange.To, this.To) };
        }
    }
}
