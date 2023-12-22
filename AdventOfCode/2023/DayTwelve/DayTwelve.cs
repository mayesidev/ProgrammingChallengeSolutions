using System.Diagnostics;

namespace _2023
{
    public class DayTwelve
    {
        public static string Solve(string filePath)
        {
            var total = 0;
            HashSet<Spring> springs = [];
            using (StreamReader reader = File.OpenText(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    var inputs = line.Split(' ', StringSplitOptions.TrimEntries);
                    springs.Add(new Spring(inputs[0], inputs[1].Split(',').Select(int.Parse)));
                }
            }

            foreach (var spring in springs)
            {
                var isValid = true;
                var segments = spring.conditions.Split('.', StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < spring.validations.Count(); i++)
                {
                    var segment = segments[i].Length;
                    var validation = spring.validations.ElementAt(i);

                    if (segment < validation)
                    {
                        isValid = false;
                        break;
                    }
                }

                Debug.WriteLine($"{spring.validations} : {spring.conditions} : {isValid}");
            }
            return total.ToString();
        }

        internal class Spring(string conditions, IEnumerable<int> validations)
        {
            public string conditions = conditions;
            public IEnumerable<int> validations = validations;
        }
    }
}