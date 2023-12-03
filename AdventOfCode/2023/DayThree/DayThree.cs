namespace _2023{
    public class DayThree{
        public static string Solve(string filePath)
        {
            using (StreamReader reader = File.OpenText(filePath))
            {
                var total = 0;
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    // total += ParseLine(line);
                }
                return total.ToString();
            }
        }
    }
}