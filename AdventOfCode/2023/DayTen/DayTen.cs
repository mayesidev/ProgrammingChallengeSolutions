using System.Diagnostics;

namespace _2023
{
    public class DayTen
    {
        public static string Solve(string filePath)
        {
            var total = 0;
            HashSet<Pipe> pipes = [];
            LinkedList<Pipe> pipeLoop = [];
            Tuple<int, int> startingPipeCoordinates = new(0, 0);
            using (StreamReader reader = File.OpenText(filePath))
            {
                var lineIndex = 1;
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    for (int i = 1; i <= line.Length; i++)
                    {
                        var pipeChar = line[i - 1];
                        if (pipeChar == 'S')
                        {
                            startingPipeCoordinates = new(lineIndex, i);
                        }

                        if (pipeChar != '.')
                        {
                            pipes.Add(new Pipe(new(lineIndex, i), DeterminePipeType(pipeChar)));
                        }
                    }
                    lineIndex++;
                }
            }

            // While not at start pipe, add next pipe to list
            // if loop fails or completes without reaching start pipe
            // go next
            List<Pipe> checkedPipes = [];
            foreach (var pipe in pipes)
            {
                var currentPipe = pipe;
                while (!checkedPipes.Contains(currentPipe))
                {
                    var nextPipe = pipes.SingleOrDefault(p => p.coordinates == DetermineNextPipeCoordinates(currentPipe));
                    if (nextPipe != null)
                    {
                        checkedPipes.Add(currentPipe);
                        currentPipe = nextPipe;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Debug.WriteLine($"{startingPipeCoordinates.Item1},{startingPipeCoordinates.Item2}");
            return total.ToString();
        }

        private static Tuple<int, int> DetermineNextPipeCoordinates(Pipe currentPipe)
        {
            return new(0, 0);
        }

        private static PipeType DeterminePipeType(char pipeChar)
        {
            var pipeType = PipeType.INVALID;
            switch (pipeChar)
            {
                case '|':
                    pipeType = PipeType.NS;
                    break;
                case '-':
                    pipeType = PipeType.EW;
                    break;
                case 'L':
                    pipeType = PipeType.NE;
                    break;
                case 'J':
                    pipeType = PipeType.NW;
                    break;
                case '7':
                    pipeType = PipeType.SW;
                    break;
                case 'F':
                    pipeType = PipeType.SE;
                    break;
            }
            return pipeType;
        }

        internal class Pipe(Tuple<int, int> coordinates, PipeType type)
        {
            public Tuple<int, int> coordinates = coordinates;
            public PipeType type = type;
        }

        public enum PipeType
        {
            INVALID,
            NS,
            EW,
            NE,
            NW,
            SW,
            SE
        }
    }
}