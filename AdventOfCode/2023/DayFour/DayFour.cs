using System.Text.RegularExpressions;

namespace _2023
{
    public class DayFour
    {
        public static string Solve(string filePath)
        {
            using (StreamReader reader = File.OpenText(filePath))
            {
                var total = 0d;
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    var firstSplit = line.Split(':',StringSplitOptions.TrimEntries);
                    var card = Regex.Match(firstSplit[0],"\\d+");
                    var numbers = firstSplit[1].Split('|',StringSplitOptions.TrimEntries);
                    var winningNumbers = numbers[0].Split(' ',StringSplitOptions.TrimEntries).Where(entry=>!entry.Equals(string.Empty));
                    var myNumbers = numbers[1].Split(' ',StringSplitOptions.TrimEntries).Where(entry=>!entry.Equals(string.Empty));

                    Console.WriteLine($"Card: {card}, winning numbers {winningNumbers.Select(winNum=>winNum).ToList()}.");

                    var points = 0d;
                    var scoreMod = 0;
                    foreach(var myNum in myNumbers)
                    {
                        if(winningNumbers.Any(wNum => wNum.Equals(myNum)))
                        {
                            points = Math.Pow(2,scoreMod);
                            Console.WriteLine($"Matched {myNum} for {points} points.");
                            scoreMod++;
                        }
                    }
                    total += points;
                }
                return total.ToString();
            }
        }
    }
}
