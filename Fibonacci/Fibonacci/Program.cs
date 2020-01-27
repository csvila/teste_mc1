using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o tamanho da sequencia.: ");
            string digitado = Console.ReadLine();

            Console.WriteLine("\nNúmero Fibonacci: ");
            Console.Write("0 ,");

            Int64 numPrimeiro = 0;
            Int64 numPegundo = 1;
            Int64 numFibonnaci = 1;
            for (int i = 0; i <= Convert.ToInt64(digitado); i++)
            {
                numFibonnaci = numPrimeiro + numPegundo;
                numPrimeiro = numPegundo;
                numPegundo = numFibonnaci;
                Console.Write(numFibonnaci + ", ");
            }
            Console.ReadLine();
        }
    }
}
