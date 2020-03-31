using System;
using System.Collections.Generic;
using System.Numerics;

namespace fibonnaci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fibonacci(5287));
        }
        static ulong Fibonacci(int n)
        {
            ulong result = 0;
            ulong previous = 1;

            for (int i = 0; i < n; i++)
            {
                ulong temp = result;
                result = previous;
                previous = temp + previous;
            }
            return result;
        }
    }

}
