using System;

namespace Fibonacci
{
    public static class Fibonacci
    {
        public static void Fibo(int n)
        {
            int a = 0;
            int b = 1;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(a);
                int temp = a;
                a = b;
                b = temp + b;
            }
        }
    }
}
