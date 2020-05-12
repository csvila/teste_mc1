using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var posicao = 5287;

            var resultado = CalcularPosicao(posicao);

            Console.WriteLine(resultado);

            Console.ReadLine();
        }

        static ulong CalcularPosicao(int posicao)
        {
            ulong a = 0;
            ulong b = 1;

            for (int i = 0; i < posicao; i++)
            {
                ulong temp = a;
                a = b;
                b = temp + b;
            }

            return a;
        }
    }
}