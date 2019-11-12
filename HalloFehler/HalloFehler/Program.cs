using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloFehler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben Sie eine Zahl ein:");
            int zahl = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Das doppelte der eingegebenen Zahl ist {zahl * 2}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
