using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace _2023
{
    public class DayFiveReverse
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
                // Console.WriteLine("Finished parsing file.");
            }

            var seedRanges = new HashSet<SeedRange>();
            for (int i = 0; i < seeds.Count; i += 2)
            {
                seedRanges.Add(new SeedRange(seeds[i], seeds[i + 1]));
            }

            long minLocation = 99999999999999;
            var location = humidityLocation.MinBy(range => range.destStart) ?? new ThingMap(99999999999999, 99999999999999, 0);

            var startLocation = location.destStart;
            var endLocation = location.destStart + location.range;

            for (var findLocation = startLocation; findLocation <= endLocation; findLocation++)
            {
                var seed = MapLocationToSeed(findLocation);
                if (seedRanges.Any(range => range.start <= seed && range.start + range.range >= seed))
                {
                    minLocation = Math.Min(minLocation, findLocation);
                    break;
                }
            }

            // minLocation = Math.Min(minLocation, seedRanges.Min(range => range.start));
            Console.WriteLine(minLocation);


            // for (int i = 0; i < seeds.Count; i += 2)
            // {
            //     var startSeed = seeds[i];
            //     var endSeed = seeds[i] + seeds[i + 1];

            //     Log($"Mapping seeds: {startSeed} to {endSeed}");
            //     var mappedLocations = new ConcurrentDictionary<long, byte>();
            //     mappedLocations.TryAdd(minLocation, 0);
            //     Parallel.For(startSeed, endSeed, seed =>
            //     {
            //         mappedLocations.TryAdd(MapSeedToLocation(seed), 0);
            //     });
            //     minLocation = mappedLocations.Keys.Min();
            //     Console.WriteLine($"Parsed seed set {i / 2 + 1}. Current min={minLocation}.");
            // }

            // Console.WriteLine(minLocation.ToString());
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

        private long MapLocationToSeed(long location)
        {
            Log($"Mapping location: {location}");

            var humidity = FindMappedValueReverse(humidityLocation, location);
            Log($"To humidity: {humidity}");

            var temperature = FindMappedValueReverse(temperatureHumidity, humidity);
            Log($"To temperature: {temperature}");

            var light = FindMappedValueReverse(lightTemperature, temperature);
            Log($"To light: {light}");

            var water = FindMappedValueReverse(waterLight, light);
            Log($"To water: {water}");

            var fertilizer = FindMappedValueReverse(fertilizerWater, water);
            Log($"To fertilizer: {fertilizer}");

            var soil = FindMappedValueReverse(soilFertilizer, fertilizer);
            Log($"To soil: {soil}");

            var seed = FindMappedValueReverse(seedSoil, soil);
            Log($"To seed: {seed}");

            return seed;
        }

        private static long FindMappedValueReverse(IEnumerable<ThingMap> mapOfThings, long valueToMap)
        {
            var foundRecord = mapOfThings.AsParallel().FirstOrDefault(mappedThing => mappedThing.destStart <= valueToMap && mappedThing.destStart + mappedThing.range >= valueToMap);
            return foundRecord != null ? foundRecord.sourceStart + (valueToMap - foundRecord.sourceStart) : valueToMap;
        }

        private static long FindMappedValue(IEnumerable<ThingMap> mapOfThings, long valueToMap)
        {

            var foundRecord = mapOfThings.AsParallel().FirstOrDefault(mappedThing => mappedThing.sourceStart <= valueToMap && mappedThing.sourceStart + mappedThing.range >= valueToMap);
            return foundRecord != null ? foundRecord.destStart + (valueToMap - foundRecord.sourceStart) : valueToMap;
        }

        internal class SeedRange(long start, long range)
        {
            public long start = start;
            public long range = range;
        }

        internal class ThingMap(long sourceStart, long destStart, long range)
        {
            public long sourceStart = sourceStart;
            public long destStart = destStart;
            public long range = range;
        }

        private static void Log(string message)
        {
            // Console.WriteLine(message);
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