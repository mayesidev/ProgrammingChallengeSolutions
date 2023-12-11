namespace _2023
{
    public class DayEleven
    {
        public static string Solve(string filePath)
        {
            HashSet<Coordinates> coordinates = [];
            using (StreamReader reader = File.OpenText(filePath))
            {
                int lineIndex = 1;
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    for (int i = 1; i <= line.Length; i++)
                    {
                        var isGalaxy = line[i - 1].Equals('#');
                        var newCoordinates = new Coordinates(lineIndex, i, isGalaxy);
                        coordinates.Add(newCoordinates);
                    }

                    lineIndex++;
                }
            }

            var colNoGalaxies = Enumerable.Range(1, coordinates.Max(coord => coord.y)).Except(coordinates.Where(coord => coord.galaxy).Select(coord => coord.y));
            var rowNoGalaxies = Enumerable.Range(1, coordinates.Max(coord => coord.x)).Except(coordinates.Where(coord => coord.galaxy).Select(coord => coord.x));

            long diffs = 0;
            var coordinatesWithGalaxies = coordinates.Where(coord => coord.galaxy);
            HashSet<Coordinates> visitedGalaxies = [];
            foreach (var galaxyCoord in coordinatesWithGalaxies)
            {
                visitedGalaxies.Add(galaxyCoord);
                var remainingGalaxies = coordinatesWithGalaxies.Except(visitedGalaxies);
                foreach (var otherGalaxyCoord in remainingGalaxies)
                {
                    // multiplier = 1 works for part 1, but part 2 needs to be problem multiplier-1 for some reason...
                    var distanceMultiplier = 999999;
                    var coordXModifier = rowNoGalaxies.Where(row => row < galaxyCoord.x).Count() * distanceMultiplier;
                    var otherCoordXModifier = rowNoGalaxies.Where(row => row < otherGalaxyCoord.x).Count() * distanceMultiplier;

                    var coordYModifer = colNoGalaxies.Where(col => col < galaxyCoord.y).Count() * distanceMultiplier;
                    var otherCoordYModifier = colNoGalaxies.Where(col => col < otherGalaxyCoord.y).Count() * distanceMultiplier;

                    var xDiff = (galaxyCoord.x + coordXModifier) - (otherGalaxyCoord.x + otherCoordXModifier);
                    var yDiff = (galaxyCoord.y + coordYModifer) - (otherGalaxyCoord.y + otherCoordYModifier);
                    diffs += Math.Abs(xDiff) + Math.Abs(yDiff);
                }
            }

            return diffs.ToString();
        }

        internal class Coordinates(int x, int y, bool galaxy)
        {
            public int x = x;
            public int y = y;
            public bool galaxy = galaxy;
        }
    }
}