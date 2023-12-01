namespace _2015
{
    public class DayOne
    {
        public static string Solve(string filePath)
        {
            using (StreamReader reader = File.OpenText(filePath))
            {
                // return PartOne(reader);
                return PartTwo(reader);
            }
        }

        private static string PartOne(StreamReader reader)
        {
            var floor = 0;
            while (!reader.EndOfStream)
            {
                string? line = reader.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                foreach (var paren in line)
                {
                    if (Equals(paren, '(')) { floor++; };
                    if (Equals(paren, ')')) { floor--; };
                }
            }
            return floor.ToString();
        }

        private static string PartTwo(StreamReader reader)
        {
            var floor = 0;
            while (!reader.EndOfStream)
            {
                string? line = reader.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                var negIndex = 0;
                foreach (var paren in line)
                {
                    if (Equals(paren, '(')) { floor++; }
                    if (Equals(paren, ')')) { floor--; }
                    negIndex++;
                    if(floor<0) { return negIndex.ToString(); }
                }
            }
            return "never negative";
        }
    }
}