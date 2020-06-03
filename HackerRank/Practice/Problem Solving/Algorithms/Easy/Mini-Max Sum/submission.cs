using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
	static void Main(String[] args)
	{
		/* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
		var minNums = new List<long>();
		var maxNums = new List<long>();
		var inStrings = Console.ReadLine().Split(' ');
		foreach(var num in inStrings)
		{
			minNums.Add(long.Parse(num));
			maxNums.Add(long.Parse(num));
		}

		minNums.Remove(minNums.Max());
		maxNums.Remove(maxNums.Min());

		Console.WriteLine("{0} {1}", minNums.Sum(), maxNums.Sum());
	}
}