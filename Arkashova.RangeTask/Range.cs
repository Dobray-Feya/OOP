using System;

namespace Arkashova.RangeTask
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

        public Range? GetIntersection(Range range)
        {
            if ((range.To <= From) || (range.From >= To))
            {
                return null;
            }

            return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
        }

        public Range[] GetUnion(Range range)
        {
            if (range.To < From)
            {
                return new Range[] { new Range(range.From, range.To), new Range(From, To) };
            }

            if (range.From > To)
            {
                return new Range[] { new Range(From, To), new Range(range.From, range.To) };
            }

            return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
        }

        public Range[] GetDifference(Range range)
        {
            if ((range.From <= From) && (range.To >= To))
            {
                return Array.Empty<Range>();  // это пустой массив
            }

            if ((range.To <= From) || (range.From >= To))
            {
                return new Range[] { new Range(From, To) };
            }

            if ((range.From > From) && (range.To < To))
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }

            if ((range.From > From) && (range.From < To) )
            {
                return new Range[] { new Range(From, range.From) };
            }

            return new Range[] { new Range(range.To, To) };
        }
    }
}
