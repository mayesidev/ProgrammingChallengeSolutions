using System;
using System.Collections.Generic;
using System.IO;

class Solution {
    
    public static int Fibonacci(int n) {
        int result;
        if(n == 0 || n == 1)
        {
            result = n;
        }
        else
        {
            result = Fibonacci(n-1) + Fibonacci(n-2);
        }
        return result;
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Fibonacci(n));
    }
}
