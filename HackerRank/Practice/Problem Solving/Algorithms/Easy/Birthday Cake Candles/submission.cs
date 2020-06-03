using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        // The first input gives us a compile warning because it is never used.
        //int n = Convert.ToInt32(Console.ReadLine());
        // This line will simply skip the first (unnecessary) input instead, which avoids the compile warning.
        Console.ReadLine();
        // It's a hack, but I can't change the inputs given in the prompt, and there's no sense
        // in keeping the compile warning and wasting memory to store this unused value in here...
        
        string[] height_temp = Console.ReadLine().Split(' ');
        int[] height = Array.ConvertAll(height_temp,Int32.Parse);
        
        int heighest = height[0];
        int heighestCount = 1;
        for(int i = 1; i < height.Length; i++)
        {
            var candle = height[i];
            if(candle > heighest)
            {
                heighest = candle;
                heighestCount = 1;
            }
            else if (candle == heighest)
            {
                heighestCount++;    
            }
        }
        
        Console.WriteLine(heighestCount);
    }
}
