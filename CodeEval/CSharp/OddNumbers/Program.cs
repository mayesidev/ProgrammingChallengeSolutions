// Print the odd numbers from 1 to 99.
namespace OddNumbers
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int i = 1;
			while (i < 100)
			{
				if (i % 2 == 1)
				{
					System.Console.Out.WriteLine(i);
				}
				i++;
			}
		}
	}
}
