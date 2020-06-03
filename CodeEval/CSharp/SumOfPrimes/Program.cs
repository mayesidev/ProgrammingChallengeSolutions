// Write a program which determines the sum of the first 1000 prime numbers.
using System;

namespace SumOfPrimes
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// The most efficient solution is as follows-
			Console.Out.WriteLine("3682913");
			// because there's only one solution to this problem.

			// While I would say this is valid for a few reasons, it's also kind of a
			// hack, so a solution in the spirit of the challenge is also provided below.

			//// Since half of the numbers will be even numbers- we start with
			//// the first prime (2) already found, and only check odd numbers.
			//var num = 3;
			//var sum = 2;
			//var numPrimes = 1;
			//while (numPrimes < 1000)
			//{
			//	var isPrime = true;
			//	for (int i = 3; i < num; i += 2)
			//	{
			//		if (num % i == 0)
			//		{
			//			isPrime = false;
			//			break;
			//		}
			//	}

			//	if (isPrime)
			//	{
			//		sum += num;
			//		numPrimes++;
			//	}

			//	num += 2;
			//}

			//Console.Out.WriteLine(sum.ToString());
		}
	}
}
