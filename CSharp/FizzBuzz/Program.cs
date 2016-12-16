// Write a program that prints out the final series of numbers where those divisible
// by X, Y and both are replaced by “F” for fizz, “B” for buzz and “FB” for fizz buzz.
using System;
using System.IO;
using System.Linq;

namespace FizzBuzz
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]) && File.Exists(args[0]))
			{
				using (StreamReader reader = File.OpenText(args[0]))
				{
					while (!reader.EndOfStream)
					{
						string line = reader.ReadLine();
						if (line.Equals(null))
						{
							continue;
						}

						var inputs = line.Split(' ');
						var parsedInputs = inputs.Select(input => int.Parse(input)).ToArray();

						var fizz = parsedInputs[0];
						var buzz = parsedInputs[1];
						var limit = parsedInputs[2];
						for (int i = 1; i <= limit; i++)
						{
							if (!(i % fizz == 0) && !(i % buzz == 0))
							{
								Console.Out.Write(i.ToString());
							}
							if (i % fizz == 0)
							{
								Console.Out.Write("F");
							}
							if (i % buzz == 0)
							{
								Console.Out.Write("B");
							}

							Console.Out.Write(" ");
						}
						Console.Out.WriteLine();
					}
				}
			}
			else
			{
				throw new InvalidArgumentException(
					"This program requires that a valid file path be passed in as the first command line argument.");
			}

			// Uncomment the following line to keep the cmd window open (for debugging purposes).
			//Console.ReadKey();
			// Be sure not to leave this uncommented when submitting a solution, as it will result in a failure.
		}
	}

	// Ideally, this custom exception would go in it's own file, but we only get to submit a single file as the solution.
	internal class InvalidArgumentException : Exception
	{
		public InvalidArgumentException()
		{
		}

		public InvalidArgumentException(string message)
			: base(message)
		{
		}

		public InvalidArgumentException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}