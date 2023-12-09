namespace _2023
{
    public class DayEight
    {
        public static string Solve(string filePath)
        {
            var total = 0;
            string directions = string.Empty;
            HashSet<Node> nodes = [];
            using (StreamReader reader = File.OpenText(filePath))
            {
                var parsingFirstLine = true;
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    if (parsingFirstLine)
                    {
                        directions = line;
                        parsingFirstLine = false;
                    }
                    else
                    {
                        var current = line[..3];
                        var left = line.Substring(7, 3);
                        var right = line.Substring(12, 3);
                        nodes.Add(new Node(current, left, right));
                    }
                }
            }

            var startingNodes = nodes.Where(node => node.current.EndsWith('A'));
            var currentIndex = 0;
            Dictionary<Node, long> distancesToFirstZ = [];
            Dictionary<Node, long> distancesToLoop = [];
            foreach (var node in startingNodes)
            {
                var currentNode = node;
                var distanceToZ = 0;
                var reachedZCount = 0;
                var distanceToLoop = 0;
                var i = 0;
                while (reachedZCount > 2)
                {
                    var direction = directions[currentIndex];
                    if (direction == 'L')
                    {
                        currentNode = nodes.Single(nextNode => node.left == nextNode.current);
                    }
                    else
                    {
                        currentNode = nodes.Single(nextNode => node.right == nextNode.current);
                    }

                    if (reachedZCount == 0)
                    {
                        distanceToZ++;
                    }
                    else if (reachedZCount == 1)
                    {
                        distanceToLoop++;
                    }
                    else
                    {
                        break;
                    }

                    if (i == directions.Length - 1)
                    {
                        i = 0;
                    }
                    else
                    {
                        i++;
                    }
                }
                distancesToFirstZ.Add(node, distanceToZ);
                distancesToLoop.Add(node, distanceToLoop);
            }

            var maxFirstLoop = distancesToFirstZ.Values.Max();
            var minLoops = LeastCommonMultiple(distancesToLoop.Values);

            return total.ToString();
        }

        private static long LeastCommonMultiple(IEnumerable<long> numbers)
        {
            return numbers.Aggregate(LeastCommonMultiple);
        }

        private static long LeastCommonMultiple(long a, long b)
        {
            return Math.Abs(a * b) / GreatestCommonDenominator(a, b);
        }
        private static long GreatestCommonDenominator(long a, long b)
        {
            return b == 0 ? a : GreatestCommonDenominator(b, a % b);
        }

        internal class Node(string current, string left, string right)
        {
            public string current = current;
            public string left = left;
            public string right = right;
        }
    }
}