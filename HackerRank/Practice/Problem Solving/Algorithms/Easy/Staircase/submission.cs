using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

	static void Main(String[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		var index = n-1;
		while(index>=0)
		{
			var line = "";
			var spaces = index;
			while(spaces>0)
			{
				line += ' ';
				spaces--;
			}
			var symbols = n - index;
			while(symbols>0)
			{
				line += '#';
				symbols--;
			}
			Console.WriteLine(line);
			index--;
		}
	}
}
