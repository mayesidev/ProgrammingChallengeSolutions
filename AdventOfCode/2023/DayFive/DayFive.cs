namespace _2023
{
    public class DayFive
    {
        public static string Solve(string filePath)
        {
            var seeds = new List<long>();
            var seedSoil = new List<ThingMap>();
            var soilFertilizer = new List<ThingMap>();
            var fertilizerWater = new List<ThingMap>();
            var waterLight = new List<ThingMap>();
            var lightTemperature = new List<ThingMap>();
            var temperatureHumidity = new List<ThingMap>();
            var humidityLocation = new List<ThingMap>();
            var currentlyParsing = ParsingMapEnum.none;
            using (StreamReader reader = File.OpenText(filePath))
            {
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

                var locations = new List<long>();
                foreach (var seed in seeds)
                {
                    Log($"Mapping seed: {seed}");

                    var soilRecord = seedSoil.FirstOrDefault(mappedThing => mappedThing.sourceStart < seed && mappedThing.sourceStart + mappedThing.range > seed);
                    var soil = soilRecord != null ? soilRecord.destStart + (seed - soilRecord.sourceStart) : seed;
                    Log($"To soil: {soil}");

                    var fertilizerRecord = soilFertilizer.FirstOrDefault(mappedThing => mappedThing.sourceStart < soil && mappedThing.sourceStart + mappedThing.range > soil);
                    var fertilizer = fertilizerRecord != null ? fertilizerRecord.destStart + (soil - fertilizerRecord.sourceStart) : soil;
                    Log($"To fertilizer: {fertilizer}");

                    var waterRecord = fertilizerWater.FirstOrDefault(mappedThing => mappedThing.sourceStart < fertilizer && mappedThing.sourceStart + mappedThing.range > fertilizer);
                    var water = waterRecord != null ? waterRecord.destStart + (fertilizer - waterRecord.sourceStart) : fertilizer;
                    Log($"To water: {water}");

                    var lightRecord = waterLight.FirstOrDefault(mappedThing => mappedThing.sourceStart < water && mappedThing.sourceStart + mappedThing.range > water);
                    var light = lightRecord != null ? lightRecord.destStart + (water - lightRecord.sourceStart) : water;
                    Log($"To light: {light}");

                    var temperatureRecord = lightTemperature.FirstOrDefault(mappedThing => mappedThing.sourceStart < light && mappedThing.sourceStart + mappedThing.range > light);
                    var temperature = temperatureRecord != null ? temperatureRecord.destStart + (light - temperatureRecord.sourceStart) : light;
                    Log($"To temperature: {temperature}");

                    var humidityRecord = temperatureHumidity.FirstOrDefault(mappedThing => mappedThing.sourceStart < temperature && mappedThing.sourceStart + mappedThing.range > temperature);
                    var humidity = humidityRecord != null ? humidityRecord.destStart + (temperature - humidityRecord.sourceStart) : temperature;
                    Log($"To humidity: {humidity}");

                    var locationRecord = humidityLocation.FirstOrDefault(mappedThing => mappedThing.sourceStart < humidity && mappedThing.sourceStart + mappedThing.range > humidity);
                    var location = locationRecord != null ? locationRecord.destStart + (humidity - locationRecord.sourceStart) : humidity;
                    Log($"To location: {location}");

                    locations.Add(location);
                }

                return locations.Min().ToString();
            }
        }

        internal class ThingMap(long sourceStart, long destStart, long range)
        {
            public long sourceStart = sourceStart;
            public long destStart = destStart;
            public long range = range;
        }

        private static void Log(string message)
        {
            Console.WriteLine(message);
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