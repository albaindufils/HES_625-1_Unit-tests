using System;

namespace Facto21
{
    class Program
    {
        static void Main(string[] args)
        {
            Factorial myFactoriel = new Factorial();
            int i;
            i = 12;
            myFactoriel.Compute(i);
            Console.WriteLine("Factorielle de (" + i + ")=" + myFactoriel.TheResult);
            Console.WriteLine("Press a key...");
            ConsoleKeyInfo result = Console.ReadKey();
        }
    }
}
