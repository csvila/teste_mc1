using System;
using System.Collections.Generic;
using System.Text;

namespace Fibo
{
    public class Calculos
    {
        public  long LoopFibonacci(int number)
        {

            long previous = 0;
            long current = 1;
            long fibo = 1;
            if (number == 0)
                return 0;
            if (number == 1)
                return fibo;

            for (long i = 2; i <= number; i++)
            {
                fibo = current + previous;
                previous = current;
                current = fibo;
            }
            return fibo;
        }
        public  long RecursiveFibonacci(int number)
        {

            if (number == 0)
                return 0;
            if (number == 1)
                return 1;
            return RecursiveFibonacci(number - 1) + RecursiveFibonacci(number - 2);

        }
    }
}
