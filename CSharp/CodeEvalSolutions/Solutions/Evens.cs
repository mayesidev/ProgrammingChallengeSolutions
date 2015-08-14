//Given a file of numbers, print 1 for evens or 0 for odds.
using System.IO;
using System.Collections.Generic;

class Evens
{
    static void PrintEvens(string[] args)
    {
        using (StreamReader reader = File.OpenText(args[0]))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;

                int num;
                int.TryParse(line, out num);

                System.Console.Out.WriteLine(num % 2 == 0 ? "1" : "0");
            }
        }
    }
}