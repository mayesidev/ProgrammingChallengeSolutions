using System.Text.RegularExpressions;

namespace _2023
{
    public class DayFour
    {
        public static string Solve(string filePath)
        {
            using (StreamReader reader = File.OpenText(filePath))
            {
                var total = 0;
                Dictionary<int, int> scoreCopies = [];
                var lineCount = 0;
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    lineCount++;
                    var firstSplit = line.Split(':', StringSplitOptions.TrimEntries);
                    var card = int.Parse(Regex.Match(firstSplit[0], "\\d+").Value);
                    var numbers = firstSplit[1].Split('|', StringSplitOptions.TrimEntries);
                    var winningNumbers = numbers[0].Split(' ', StringSplitOptions.TrimEntries).Where(entry => !entry.Equals(string.Empty));
                    var myNumbers = numbers[1].Split(' ', StringSplitOptions.TrimEntries).Where(entry => !entry.Equals(string.Empty));

                    var numCopies = scoreCopies.TryGetValue(card, out int outCopies) ? outCopies + 1 : 1;
                    while (numCopies > 0)
                    {
                        // Console.WriteLine($"Card: {card}, winning numbers {winningNumbers.Aggregate((string1, string2) => $"{string1},{string2}")}.");
                        var numMatches = 1;
                        foreach (var myNum in myNumbers)
                        {
                            if (winningNumbers.Any(wNum => wNum.Equals(myNum)))
                            {
                                var copyIndex = card + numMatches;
                                if (!scoreCopies.TryGetValue(copyIndex, out int copyCount))
                                {
                                    copyCount = 0;
                                }
                                scoreCopies[copyIndex] = ++copyCount;

                                // Console.WriteLine($"Match! Card: {copyIndex}, CopyCount: {copyCount}");
                                numMatches++;
                            }
                        }
                        numCopies--;
                    }
                }
                total = lineCount + scoreCopies.Values.Sum();
                return total.ToString();
            }
        }

        private static double ScorePartOne(IEnumerable<string> myNumbers, IEnumerable<string> winningNumbers)
        {
            var points = 0d;
            var scoreMod = 0;
            foreach (var myNum in myNumbers)
            {
                if (winningNumbers.Any(wNum => wNum.Equals(myNum)))
                {
                    points = Math.Pow(2, scoreMod);
                    Console.WriteLine($"Matched {myNum} for {points} points.");
                    scoreMod++;
                }
            }
            return points;
        }
    }
}
