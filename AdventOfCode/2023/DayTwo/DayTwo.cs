
using System.Text.RegularExpressions;

namespace _2023
{
    public class DayTwo
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

                    // total += SolvePartOne(line);
                    total += SolvePartTwo(line);
                }
                return total.ToString();
            }
        }

        private static int SolvePartOne(string line)
        {
            var maxRed = 12;
            var maxGreen = 13;
            var maxBlue = 14;
            var gameInfo = line.Split(':', StringSplitOptions.TrimEntries);
            var gameID = int.Parse(Regex.Match(gameInfo[0], "\\d+").Value);
            var gameDetails = gameInfo[1].Split(';', StringSplitOptions.TrimEntries);
            bool isPossible = true;
            foreach (var detail in gameDetails)
            {
                if (!isPossible)
                {
                    break;
                }
                var roundDetails = detail.Split(',', StringSplitOptions.TrimEntries);
                foreach (var rDetail in roundDetails)
                {
                    if (!isPossible)
                    {
                        break;
                    }
                    if (rDetail.Contains("red") && int.Parse(Regex.Match(rDetail, "\\d+").Value) > maxRed)
                    {
                        isPossible = false;
                    }
                    if (rDetail.Contains("green") && int.Parse(Regex.Match(rDetail, "\\d+").Value) > maxGreen)
                    {
                        isPossible = false;
                    }
                    if (rDetail.Contains("blue") && int.Parse(Regex.Match(rDetail, "\\d+").Value) > maxBlue)
                    {
                        isPossible = false;
                    }
                }
            }
            if (isPossible) { return gameID; }
            else { return 0; }
        }

        private static int SolvePartTwo(string line)
        {
            var maxRed = 0;
            var maxGreen = 0;
            var maxBlue = 0;
            var gameInfo = line.Split(':', StringSplitOptions.TrimEntries);
            var gameID = int.Parse(Regex.Match(gameInfo[0], "\\d+").Value);
            var gameDetails = gameInfo[1].Split(';', StringSplitOptions.TrimEntries);

            foreach (var detail in gameDetails)
            {
                var roundDetails = detail.Split(',', StringSplitOptions.TrimEntries);
                foreach (var rDetail in roundDetails)
                {
                    if (rDetail.Contains("red") && int.TryParse(Regex.Match(rDetail, "\\d+").Value, out int redCount) && redCount>maxRed)
                    {
                        maxRed = redCount;
                    }
                    if (rDetail.Contains("green") && int.TryParse(Regex.Match(rDetail, "\\d+").Value, out int greenCount) && greenCount>maxGreen)
                    {
                        maxGreen = greenCount;
                    }
                    if (rDetail.Contains("blue") && int.TryParse(Regex.Match(rDetail, "\\d+").Value, out int blueCount) && blueCount>maxBlue)
                    {
                        maxBlue = blueCount;
                    }
                }
            }

            return maxRed*maxGreen*maxBlue;
        }
    }
}