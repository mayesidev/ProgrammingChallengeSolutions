//Paste current solution's code in here for testing the same as their submission form.
using System.IO;

class Program
{
    static void Main(string[] args)
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
