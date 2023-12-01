using System.Text.RegularExpressions;

namespace _2023
{
    public class DayOne
    {
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

                    total += ParseLine(line);
                }
                return total.ToString();
            }
        }

        private static int ParseLine(string line)
        {
            string firstNumString = Regex.Matches(line, @"(\d)|(one)|(two)|(three)|(four)|(five)|(six)|(seven)|(eight)|(nine)").First().Value;
            if (!int.TryParse(firstNumString, out int firstNum))
            {
                firstNum = ParseWord(firstNumString);
            }

            string lastNumString = Regex.Matches(line, @"(\d)|(one)|(two)|(three)|(four)|(five)|(six)|(seven)|(eight)|(nine)",RegexOptions.RightToLeft).First().Value;
            if (!int.TryParse(lastNumString, out int lastNum))
            {
                lastNum = ParseWord(lastNumString);
            }

            return int.Parse($"{firstNum}{lastNum}");
        }

        private static int ParseWord(string word)
        {
            int num;
            switch (word)
            {
                case "one":
                    num = 1;
                    break;
                case "two":
                    num = 2;
                    break;
                case "three":
                    num = 3;
                    break;
                case "four":
                    num = 4;
                    break;
                case "five":
                    num = 5;
                    break;
                case "six":
                    num = 6;
                    break;
                case "seven":
                    num = 7;
                    break;
                case "eight":
                    num = 8;
                    break;
                case "nine":
                    num = 9;
                    break;
                default:
                    throw new Exception();
            }
            return num;
        }
    }
}
