using System;
using System.Diagnostics;

namespace Fibo
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculos calculador = new Calculos();
            Console.WriteLine("Digite um numero para calculo da sequência Fibo");
            int number;
            number = Convert.ToInt32(Console.ReadLine());
            Stopwatch lSw = new Stopwatch();
            lSw.Start();
            long loop = calculador.LoopFibonacci(number);
            lSw.Stop();
            Stopwatch rSw = new Stopwatch();
            rSw.Start();
            long recursive = calculador.RecursiveFibonacci(number);
            rSw.Stop();
            Console.WriteLine($"LoopFibonacci: {loop} ElapsedTime: {lSw.Elapsed} ");
            Console.WriteLine($"RecursiveFibonacci: {recursive} ElapsedTime: {rSw.Elapsed} ");
            Console.ReadKey();

        }
       
    }
}
