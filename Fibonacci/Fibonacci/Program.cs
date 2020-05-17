using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int termo;

            Console.WriteLine("Insira a quantidade de termos da sequência");
            Console.Write("\n");

            termo = int.Parse(Console.ReadLine());



            Iterativa(termo);
            //Recursiva(termo);



            Console.WriteLine("\n");
            Console.WriteLine("Execução encerrada, tecle enter para sair...");
            Console.ReadLine();
        }

        private static void Iterativa(int termo)
        {
            long anterior = 0, atual = 1, auxiliar = 0;

            Console.Write($"{anterior} {atual}");

            for (int i = 2; i <= termo; i++)
            {
                auxiliar = anterior + atual;

                Console.Write($" {auxiliar}");

                anterior = atual;
                atual = auxiliar;
            }
        }

        private static void Recursiva(int termo)
        {

            for (int i = 0; i <= termo; i++)
            {
                Console.Write($"{Fibonacci(i)} ");
            }

        }

        public static long Fibonacci(int termo)
        {
            if (termo == 0)
            {
                return 0;
            }
            else if (termo == 1)
            {
                return 1;
            }
            else
            {
                return Fibonacci(termo - 1) + Fibonacci(termo - 2);
            }
        }
    }
}
