using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace _2023
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText("./input.txt"))
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
                Console.WriteLine(total);
            }
        }

        public static int ParseLine(string line)
        {
            // HACK: Drop first character and find next match.
            // This will result in repeated matches throughout the middle, but first and last will be fine.
            // This is needed because of overlapping cases like "eightwo", which is intended to find [8,2], but would just find [8], and if that is at the end of the line then the last match is wrong.
            // Would have been faster to forward search and take first match as firstNum, then backwards search and take first match as lastNum...
            Collection<string> nums = [];
            while (line.Length >= 1)
            {
                var firstMatch = Regex.Matches(line, @"(\d)|(one)|(two)|(three)|(four)|(five)|(six)|(seven)|(eight)|(nine)").FirstOrDefault();
                if (firstMatch != null)
                {
                    nums.Add(firstMatch.Value);
                }
                line = line[1..];
            }

            string firstNumString = nums[0];
            if (!int.TryParse(firstNumString, out int firstNum))
            {
                firstNum = ParseWord(firstNumString);
            }

            string lastNumString = nums[^1];
            if (!int.TryParse(lastNumString, out int lastNum))
            {
                lastNum = ParseWord(lastNumString);
            }

            return int.Parse($"{firstNum}{lastNum}");
        }

        public static int ParseWord(string word)
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
