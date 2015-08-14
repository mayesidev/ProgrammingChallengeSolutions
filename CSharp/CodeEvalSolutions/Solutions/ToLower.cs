// Read input from a file, and print it back out in all lower case.
using System.IO;
using System.Collections.Generic;

class ToLower
{
    static void PrintLower(string[] args)
    {
        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;

                System.Console.Out.WriteLine(line.ToLower());
            }
    }
}