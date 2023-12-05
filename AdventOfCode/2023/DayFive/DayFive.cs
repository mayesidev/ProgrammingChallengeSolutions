namespace _2023
{
    public class DayFive
    {
        public static string Solve(string filePath)
        {
            var seeds = new List<long>();
            var seedSoil = new Dictionary<long, long>();
            var soilFertilizer = new Dictionary<long, long>();
            var fertilizerWater = new Dictionary<long, long>();
            var waterLight = new Dictionary<long, long>();
            var lightTemperature = new Dictionary<long, long>();
            var temperatureHumidity = new Dictionary<long, long>();
            var humidityLocation = new Dictionary<long, long>();
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

                        while (rangeNum > 0)
                        {
                            Log($"seed {sourceNum} to soil {destinationNum}");
                            seedSoil.Add(sourceNum, destinationNum);
                            destinationNum++;
                            sourceNum++;
                            rangeNum--;
                        }
                    }
                    else if (currentlyParsing == ParsingMapEnum.soilFertilizer)
                    {
                        var inputs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                        var destinationNum = inputs[0];
                        var sourceNum = inputs[1];
                        var rangeNum = inputs[2];

                        while (rangeNum > 0)
                        {
                            Log($"soil {sourceNum} to fertilizer {destinationNum}");
                            soilFertilizer.Add(sourceNum, destinationNum);
                            destinationNum++;
                            sourceNum++;
                            rangeNum--;
                        }
                    }
                    else if (currentlyParsing == ParsingMapEnum.fertilizerWater)
                    {
                        var inputs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                        var destinationNum = inputs[0];
                        var sourceNum = inputs[1];
                        var rangeNum = inputs[2];

                        while (rangeNum > 0)
                        {
                            Log($"fertilizer {sourceNum} to water {destinationNum}");
                            fertilizerWater.Add(sourceNum, destinationNum);
                            destinationNum++;
                            sourceNum++;
                            rangeNum--;
                        }
                    }
                    else if (currentlyParsing == ParsingMapEnum.waterLight)
                    {
                        var inputs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                        var destinationNum = inputs[0];
                        var sourceNum = inputs[1];
                        var rangeNum = inputs[2];

                        while (rangeNum > 0)
                        {
                            Log($"water {sourceNum} to light {destinationNum}");
                            waterLight.Add(sourceNum, destinationNum);
                            destinationNum++;
                            sourceNum++;
                            rangeNum--;
                        }
                    }
                    else if (currentlyParsing == ParsingMapEnum.lightTemperature)
                    {
                        var inputs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                        var destinationNum = inputs[0];
                        var sourceNum = inputs[1];
                        var rangeNum = inputs[2];

                        while (rangeNum > 0)
                        {
                            Log($"light {sourceNum} to temperature {destinationNum}");
                            lightTemperature.Add(sourceNum, destinationNum);
                            destinationNum++;
                            sourceNum++;
                            rangeNum--;
                        }
                    }
                    else if (currentlyParsing == ParsingMapEnum.temperatureHumidity)
                    {
                        var inputs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                        var destinationNum = inputs[0];
                        var sourceNum = inputs[1];
                        var rangeNum = inputs[2];

                        while (rangeNum > 0)
                        {
                            Log($"temperature {sourceNum} to humidity {destinationNum}");
                            temperatureHumidity.Add(sourceNum, destinationNum);
                            destinationNum++;
                            sourceNum++;
                            rangeNum--;
                        }
                    }
                    else if (currentlyParsing == ParsingMapEnum.humidityLocation)
                    {
                        var inputs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                        var destinationNum = inputs[0];
                        var sourceNum = inputs[1];
                        var rangeNum = inputs[2];

                        while (rangeNum > 0)
                        {
                            Log($"humidity {sourceNum} to location {destinationNum}");
                            humidityLocation.Add(sourceNum, destinationNum);
                            destinationNum++;
                            sourceNum++;
                            rangeNum--;
                        }
                    }
                }

                var locations = new List<long>();
                foreach (var seed in seeds)
                {
                    Log($"Mapping seed: {seed}");
                    var soil = seedSoil.TryGetValue(seed, out long foundSoil) ? foundSoil : seed;
                    Log($"To soil: {soil}");

                    var fertilizer = soilFertilizer.TryGetValue(soil, out long foundFertilizer) ? foundFertilizer : soil;
                    Log($"To fertilizer: {fertilizer}");

                    var water = fertilizerWater.TryGetValue(fertilizer, out long foundWater) ? foundWater : fertilizer;
                    Log($"To water: {water}");

                    var light = waterLight.TryGetValue(water, out long foundLight) ? foundLight : water;
                    Log($"To light: {light}");

                    var temperature = lightTemperature.TryGetValue(light, out long foundTemperature) ? foundTemperature : light;
                    Log($"To temperature: {temperature}");

                    var humidity = temperatureHumidity.TryGetValue(temperature, out long foundHumidity) ? foundHumidity : temperature;
                    Log($"To humidity: {humidity}");

                    var location = humidityLocation.TryGetValue(humidity, out long foundLocation) ? foundLocation : humidity;
                    Log($"To location: {location}");

                    locations.Add(location);
                }

                return locations.Min().ToString();
            }
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