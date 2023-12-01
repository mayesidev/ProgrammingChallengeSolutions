
namespace _2023
{
    public class DayTwo
    {
        public static string Solve(string filePath)
        {
            using (StreamReader reader = File.OpenText(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    // TODO: per line action here
                }
                return "not yet implemented";
            }
        }
    }
}