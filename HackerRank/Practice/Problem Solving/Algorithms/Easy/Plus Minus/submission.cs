using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

	static void Main(String[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		string[] arr_temp = Console.ReadLine().Split(' ');
		int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

		double positiveCount = 0;
		double negativeCount = 0;
		double zeroCount = 0;

		foreach( var num in arr)
		{
			if(num>0)
			{
				positiveCount++;
			}
			else if(num < 0)
			{
				negativeCount++;
			}
			else
			{
				zeroCount++;
			}
		}

		Console.WriteLine(positiveCount / arr.Length);
		Console.WriteLine(negativeCount / arr.Length);
		Console.WriteLine(zeroCount / arr.Length);
	}
}
