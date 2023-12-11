using System.Diagnostics;

namespace _2023
{
    public class DayEleven
    {
        public static string Solve(string filePath)
        {
            var total = 0;
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

                    var foundGalaxy = false;
                    HashSet<Coordinates> dupedCoordinates = [];
                    for (int i = 1; i <= line.Length; i++)
                    {
                        var isGalaxy = line[i - 1].Equals('#');
                        var newCoordinates = new Coordinates(lineIndex, i, isGalaxy);
                        coordinates.Add(newCoordinates);

                        if (isGalaxy)
                        {
                            foundGalaxy = true;
                        }
                        else
                        {
                            dupedCoordinates.Add(new Coordinates(lineIndex + 1, i, isGalaxy));
                        }
                    }

                    // Account for doubling blank rows
                    if (!foundGalaxy)
                    {
                        coordinates.UnionWith(dupedCoordinates);
                        lineIndex++;
                    }

                    lineIndex++;
                }
            }

            // Account for doubling blank cols
            var colNoGalaxies = Enumerable.Range(1, coordinates.Max(coord => coord.y)).Except(coordinates.Where(coord => coord.galaxy).Select(coord => coord.y));
            HashSet<Coordinates> fixedCoordinates = [];
            foreach (var coordinate in coordinates)
            {
                var numberOfAddedColumns = colNoGalaxies.Where(col => col < coordinate.y).Count();
                var newY = coordinate.y + numberOfAddedColumns;

                fixedCoordinates.Add(new Coordinates(coordinate.x, newY, coordinate.galaxy));

                if (colNoGalaxies.Contains(coordinate.y))
                {
                    fixedCoordinates.Add(new Coordinates(coordinate.x, newY + 1, coordinate.galaxy));
                }
            }

            coordinates = fixedCoordinates;

            List<long> diffs = [];
            var coordinatesWithGalaxies = coordinates.Where(coord => coord.galaxy);
            HashSet<Coordinates> visitedGalaxies = [];
            foreach (var galaxyCoord in coordinatesWithGalaxies)
            {
                visitedGalaxies.Add(galaxyCoord);
                var remainingGalaxies = coordinatesWithGalaxies.Except(visitedGalaxies);
                foreach (var otherGalaxyCoord in remainingGalaxies)
                {
                    var xDiff = galaxyCoord.x - otherGalaxyCoord.x;
                    var yDiff = galaxyCoord.y - otherGalaxyCoord.y;
                    diffs.Add(Math.Abs(xDiff) + Math.Abs(yDiff));
                }
            }

            return diffs.Sum().ToString();
        }

        internal class Coordinates(int x, int y, bool galaxy)
        {
            public int x = x;
            public int y = y;
            public bool galaxy = galaxy;
        }
    }
}