using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

	static int[] solve(int a0, int a1, int a2, int b0, int b1, int b2)
	{
		// Complete this function
		var round0 = judge(a0, b0);
		var round1 = judge(a1, b1); 
		var round2 = judge(a2, b2);

		var aScore = 0;
		var bScore = 0;

		if(round0 != null)
		{
			if(round0.Value)
			{
				aScore++;
			}
			else
			{
				bScore++;
			}
		}
		if (round1 != null)
		{
			if (round1.Value)
			{
				aScore++;
			}
			else
			{
				bScore++;
			}
		}
		if (round2 != null)
		{
			if (round2.Value)
			{
				aScore++;
			}
			else
			{
				bScore++;
			}
		}
		return new[] { aScore, bScore };
	}

	static bool? judge(int a, int b)
	{
		bool? result = null;
		if (a > b)
		{
			result = true;
		}
		else if (a < b)
		{
			result = false;
		}
		return result;
	}

	static void Main(String[] args)
	{
		string[] tokens_a0 = Console.ReadLine().Split(' ');
		int a0 = Convert.ToInt32(tokens_a0[0]);
		int a1 = Convert.ToInt32(tokens_a0[1]);
		int a2 = Convert.ToInt32(tokens_a0[2]);
		string[] tokens_b0 = Console.ReadLine().Split(' ');
		int b0 = Convert.ToInt32(tokens_b0[0]);
		int b1 = Convert.ToInt32(tokens_b0[1]);
		int b2 = Convert.ToInt32(tokens_b0[2]);
		int[] result = solve(a0, a1, a2, b0, b1, b2);
		Console.WriteLine(String.Join(" ", result));
		Console.ReadKey();
	}
}
