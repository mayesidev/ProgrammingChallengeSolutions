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
		UInt64[] arr = Array.ConvertAll(arr_temp, UInt64.Parse);

		var total = arr[0];
		for(var i =1; i<arr.Length; i++)
		{
			total += arr[i];
		}

		Console.WriteLine(total);
	}
}
