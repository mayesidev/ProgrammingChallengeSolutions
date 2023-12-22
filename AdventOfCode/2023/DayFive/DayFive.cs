using System.Collections.Concurrent;
using System.Diagnostics;

namespace _2023
{
    public class DayFive
    {
        internal HashSet<ThingMap> seedSoil = [];
        internal HashSet<ThingMap> soilFertilizer = [];
        internal HashSet<ThingMap> fertilizerWater = [];
        internal HashSet<ThingMap> waterLight = [];
        internal HashSet<ThingMap> lightTemperature = [];
        internal HashSet<ThingMap> temperatureHumidity = [];
        internal HashSet<ThingMap> humidityLocation = [];

        public void Solve(string filePath)
        {
            var seeds = new List<long>();

            using (StreamReader reader = File.OpenText(filePath))
            {
                var currentlyParsing = ParsingMapEnum.none;
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    if (line.StartsWith("seeds", StringComparison.OrdinalIgnoreCase))
                    {
                        Log("Parsing seed list.");
                        var seedNums = line.Split(':', StringSplitOptions.TrimEntries)[1];
                        seeds.AddRange(seedNums.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse));
                    }
                    else if (line.StartsWith("seed-to-soil", StringComparison.OrdinalIgnoreCase))
                    {
                        Log("Parsing seed-to-soil.");
                        currentlyParsing = ParsingMapEnum.seedSoil;
                    }
                    else if (line.StartsWith("soil-to-fertilizer", StringComparison.OrdinalIgnoreCase))
                    {
                        Log("Parsing soil-to-fertilizer.");
                        currentlyParsing = ParsingMapEnum.soilFertilizer;
                    }
                    else if (line.StartsWith("fertilizer-to-water", StringComparison.OrdinalIgnoreCase))
                    {
                        Log("Parsing fertilizer-to-water.");
                        currentlyParsing = ParsingMapEnum.fertilizerWater;
                    }
                    else if (line.StartsWith("water-to-light", StringComparison.OrdinalIgnoreCase))
                    {
                        Log("Parsing water-to-light.");
                        currentlyParsing = ParsingMapEnum.waterLight;
                    }
                    else if (line.StartsWith("light-to-temperature", StringComparison.OrdinalIgnoreCase))
                    {
                        Log("Parsing light-to-temperature.");
                        currentlyParsing = ParsingMapEnum.lightTemperature;
                    }
                    else if (line.StartsWith("temperature-to-humidity", StringComparison.OrdinalIgnoreCase))
                    {
                        Log("Parsing temperature-to-humidity.");
                        currentlyParsing = ParsingMapEnum.temperatureHumidity;
                    }
                    else if (line.StartsWith("humidity-to-location", StringComparison.OrdinalIgnoreCase))
                    {
                        Log("Parsing humidity-to-location.");
                        currentlyParsing = ParsingMapEnum.humidityLocation;
                    }
                    else if (currentlyParsing == ParsingMapEnum.seedSoil)
                    {
                        var inputs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                        var destinationNum = inputs[0];
                        var sourceNum = inputs[1];
                        var rangeNum = inputs[2];

                        Log($"seeds: {sourceNum}, soils: {destinationNum}, range: {rangeNum}");
                        seedSoil.Add(new ThingMap(sourceNum, destinationNum, rangeNum));
                    }
                    else if (currentlyParsing == ParsingMapEnum.soilFertilizer)
                    {
                        var inputs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                        var destinationNum = inputs[0];
                        var sourceNum = inputs[1];
                        var rangeNum = inputs[2];

                        Log($"soil: {sourceNum}, fertilizer: {destinationNum}, range: {rangeNum}");
                        soilFertilizer.Add(new ThingMap(sourceNum, destinationNum, rangeNum));
                    }
                    else if (currentlyParsing == ParsingMapEnum.fertilizerWater)
                    {
                        var inputs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                        var destinationNum = inputs[0];
                        var sourceNum = inputs[1];
                        var rangeNum = inputs[2];

                        Log($"fertilizer: {sourceNum}, water: {destinationNum}, range: {rangeNum}");
                        fertilizerWater.Add(new ThingMap(sourceNum, destinationNum, rangeNum));
                    }
                    else if (currentlyParsing == ParsingMapEnum.waterLight)
                    {
                        var inputs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                        var destinationNum = inputs[0];
                        var sourceNum = inputs[1];
                        var rangeNum = inputs[2];

                        Log($"water: {sourceNum}, light: {destinationNum}, range: {rangeNum}");
                        waterLight.Add(new ThingMap(sourceNum, destinationNum, rangeNum));
                    }
                    else if (currentlyParsing == ParsingMapEnum.lightTemperature)
                    {
                        var inputs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                        var destinationNum = inputs[0];
                        var sourceNum = inputs[1];
                        var rangeNum = inputs[2];

                        Log($"light: {sourceNum}, temperature: {destinationNum}, range: {rangeNum}");
                        lightTemperature.Add(new ThingMap(sourceNum, destinationNum, rangeNum));
                    }
                    else if (currentlyParsing == ParsingMapEnum.temperatureHumidity)
                    {
                        var inputs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                        var destinationNum = inputs[0];
                        var sourceNum = inputs[1];
                        var rangeNum = inputs[2];

                        Log($"temperature: {sourceNum}, humidity: {destinationNum}, range: {rangeNum}");
                        temperatureHumidity.Add(new ThingMap(sourceNum, destinationNum, rangeNum));
                    }
                    else if (currentlyParsing == ParsingMapEnum.humidityLocation)
                    {
                        var inputs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                        var destinationNum = inputs[0];
                        var sourceNum = inputs[1];
                        var rangeNum = inputs[2];

                        Log($"humidity: {sourceNum}, location: {destinationNum}, range: {rangeNum}");
                        humidityLocation.Add(new ThingMap(sourceNum, destinationNum, rangeNum));
                    }
                }
                Debug.WriteLine("Finished parsing file.");
            }

            HashSet<ThingMap> fullMap = [];
            foreach (var thing in seedSoil)
            {
                fullMap.Add(new ThingMap(thing.sourceStart, thing.destStart, thing.range));
            }

            long minLocation = 99999999999999;
            for (int i = 0; i < seeds.Count; i += 2)
            {
                var startSeed = seeds[i];
                var endSeed = seeds[i] + seeds[i + 1];

                Log($"Mapping seeds: {startSeed} to {endSeed}");
                var mappedLocations = new ConcurrentDictionary<long, byte>();
                mappedLocations.TryAdd(minLocation, 0);
                Parallel.For(startSeed, endSeed, seed =>
                {
                    mappedLocations.TryAdd(MapSeedToLocation(seed), 0);
                });
                minLocation = mappedLocations.Keys.Min();
                Debug.WriteLine($"Parsed seed set {i / 2 + 1}. Current min={minLocation}.");
            }

            Debug.WriteLine(minLocation.ToString());
        }

        private HashSet<ThingMap> combineMapCollections(HashSet<ThingMap> firstMapCollection, HashSet<ThingMap> nextMapCollection)
        {
            HashSet<ThingMap> combinedMaps = [];
            foreach (var nextMap in nextMapCollection)
            {
                var overlap = firstMapCollection.Where(firstMap => Utilities.RangesOverlap(
                    firstMap.destStart,
                    firstMap.destStart + firstMap.range,
                    nextMap.sourceStart,
                    nextMap.sourceStart + nextMap.range));

                if (overlap.Any())
                {

                }
            }
            return combinedMaps;
        }

        private long MapSeedToLocation(long seed)
        {
            Log($"Mapping seed: {seed}");
            var soil = FindMappedValue(seedSoil, seed);
            Log($"To soil: {soil}");

            var fertilizer = FindMappedValue(soilFertilizer, soil);
            Log($"To fertilizer: {fertilizer}");

            var water = FindMappedValue(fertilizerWater, fertilizer);
            Log($"To water: {water}");

            var light = FindMappedValue(waterLight, water);
            Log($"To light: {light}");

            var temperature = FindMappedValue(lightTemperature, light);
            Log($"To temperature: {temperature}");

            var humidity = FindMappedValue(temperatureHumidity, temperature);
            Log($"To humidity: {humidity}");

            var location = FindMappedValue(humidityLocation, humidity);
            Log($"To location: {location}");

            return location;
        }

        private static long FindMappedValue(IEnumerable<ThingMap> mapOfThings, long valueToMap)
        {
            var foundRecord = mapOfThings.FirstOrDefault(mappedThing => mappedThing.sourceStart <= valueToMap && mappedThing.sourceStart + mappedThing.range >= valueToMap);
            return foundRecord != null ? foundRecord.destStart + (valueToMap - foundRecord.sourceStart) : valueToMap;
        }

        internal class ThingMap(long sourceStart, long destStart, long range)
        {
            public long sourceStart = sourceStart;
            public long destStart = destStart;
            public long range = range;

            public long GetOffset()
            {
                return destStart - sourceStart;
            }
        }

        private static void Log(string message)
        {
            Debug.WriteLine(message);
        }

        private enum ParsingMapEnum
        {
            none,
            seedSoil,
            soilFertilizer,
            fertilizerWater,
            waterLight,
            lightTemperature,
            temperatureHumidity,
            humidityLocation
        }
    }
}

//20358600 too high