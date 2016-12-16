// TODO: write problem description here.
using System;
using System.IO;

namespace $safeprojectname$
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
	
						// TODO: do something with line to solve the problem.
	
						// TODO: write the solution to the problem as output.
						Console.Out.WriteLine( /*solution*/ );
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