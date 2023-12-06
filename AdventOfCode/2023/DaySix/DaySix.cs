namespace _2023
{
    public class DaySix
    {
        public static string Solve(string filePath)
        {
            int total = 1;
            IEnumerable<int> times = [];
            IEnumerable<int> distances = [];
            using (StreamReader reader = File.OpenText(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    var input = line.Split(":", StringSplitOptions.TrimEntries);
                    var inputNums = input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
                    if (input[0].StartsWith("Time"))
                    {
                        times = inputNums;
                    }
                    else
                    {
                        distances = inputNums;
                    }
                }
            }

            for (int i = 0; i < times.Count(); i++)
            {
                var time = times.ElementAt(i);
                var recordDistance = distances.ElementAt(i);
                var foundDistances = 0;
                var holdTime = 1;
                while (holdTime < time)
                {
                    if (holdTime * (time - holdTime) > recordDistance)
                    {
                        foundDistances++;
                    }
                    holdTime++;
                }
                total *= foundDistances;
            }

            return total.ToString();
        }

        public static string SolvePart2(string filePath)
        {
            long total = 0;
            long times = -1;
            long distances = -1;
            using (StreamReader reader = File.OpenText(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    var input = line.Split(":", StringSplitOptions.TrimEntries);
                    var inputNums = long.Parse(input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Aggregate((first, next) => $"{first}{next}"));
                    if (input[0].StartsWith("Time"))
                    {
                        times = inputNums;
                    }
                    else
                    {
                        distances = inputNums;
                    }
                }
            }

            var holdTime = 1;
            while (holdTime < times)
            {
                if (holdTime * (times - holdTime) > distances)
                {
                    total++;
                }
                holdTime++;
            }

            return total.ToString();
        }
    }
}