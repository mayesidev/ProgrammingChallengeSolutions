using System.Diagnostics;

namespace _2023
{
    public class DayNine
    {
        public static string Solve(string filePath)
        {
            var total = 0L;
            Dictionary<int, IEnumerable<long>> sequences = [];
            var lineIndex = 1;
            using (StreamReader reader = File.OpenText(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    sequences.Add(lineIndex, line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse));
                    lineIndex++;
                }
            }

            foreach (var sequence in sequences)
            {
                Dictionary<int, IEnumerable<long>> subsequences = [];
                var currentSequence = sequence.Value.ToArray();
                var currentIndex = 1;
                while (!currentSequence.All(val => val == 0))
                {
                    var nextSequence = CalcSequenceDiff(currentSequence);
                    subsequences.Add(currentIndex, nextSequence);
                    currentSequence = nextSequence.ToArray();
                    currentIndex++;

                    //Debug.WriteLine($"Line: {sequence.Key} Subsequence: {currentIndex} Length: {nextSequence.Count()}");
                }

                var previouslyAddedValue = 0L;
                for (var i = subsequences.Count - 1; i > 0; i--)
                {
                    previouslyAddedValue = subsequences[i].First() - previouslyAddedValue;
                    // Debug.WriteLine($"Line: {sequence.Key} Subsequence: {i} Added: {previouslyAddedValue}");
                }
                total += sequence.Value.First() - previouslyAddedValue;
            }
            return total.ToString();
        }

        public static IEnumerable<long> CalcSequenceDiff(long[] sequence)
        {
            List<long> subsequence = [];
            for (var i = 0; i < sequence.Length - 1; i++)
            {
                subsequence.Add(sequence[i + 1] - sequence[i]);
            }
            return subsequence;
        }
    }
}