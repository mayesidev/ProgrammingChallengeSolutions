namespace _2023
{
    public static class Utilities
    {

        public static bool RangesOverlap(long firstRangeStart, long firstRangeEnd, long secondRangeStart, long secondRangeEnd)
        {
            return IsBetween(firstRangeStart, secondRangeStart, secondRangeEnd) // first range starts inside second range
                || IsBetween(firstRangeEnd, secondRangeStart, secondRangeEnd) // first range ends inside second range
                || IsBetween(secondRangeStart, firstRangeStart, firstRangeEnd) // second range starts inside of first range
                || IsBetween(secondRangeEnd, firstRangeStart, firstRangeEnd); // second range ends inside of first range
        }

        public static bool IsBetween(long value, long start, long end)
        {
            return start <= value && value <= end;
        }

        public static long LeastCommonMultiple(IEnumerable<long> numbers)
        {
            return numbers.Aggregate(LeastCommonMultiple);
        }

        public static long LeastCommonMultiple(long a, long b)
        {
            return Math.Abs(a * b) / GreatestCommonDenominator(a, b);
        }

        public static long GreatestCommonDenominator(long a, long b)
        {
            return b == 0 ? a : GreatestCommonDenominator(b, a % b);
        }
    }
}