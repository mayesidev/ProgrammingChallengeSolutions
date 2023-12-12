namespace _2023
{
    public class DayTwelve
    {
        public static string Solve(string filePath)
        {
            var total = 0;
            using (StreamReader reader = File.OpenText(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    // total += ParseLine(line);
                }
            }
            return total.ToString();
        }
    }
}