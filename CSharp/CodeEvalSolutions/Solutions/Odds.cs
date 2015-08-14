//Print the odd numbers from 1-99.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalSolutions.Solutions
{
    class Odds
    {
        public void PrintOdds()
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
