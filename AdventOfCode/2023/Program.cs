using System.Net;
using System.Text.RegularExpressions;

namespace _2023
{
    public class Program {
		public static void Main(string[] args)
		{
                using (StreamReader reader = File.OpenText("./input.txt"))
				{
                    var total = 0;
					while (!reader.EndOfStream)
					{
						string? line = reader.ReadLine();
						if (string.IsNullOrEmpty(line))
						{
							continue;
						}
	
                        total += ParseLine(line);
					}
                    Console.WriteLine(total);
				}
		}

         public static int ParseLine(string line)
        {
            var nums = Regex.Matches(line, @"\d");

            return int.Parse(string.Concat(nums[0].Value,nums[nums.Count-1].Value));
        }
	}
}

