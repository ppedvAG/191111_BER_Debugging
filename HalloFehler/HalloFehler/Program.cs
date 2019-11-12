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
            string eingabe = Console.ReadLine();
            bool flag = false;
            string demo = "demostring 12345";
            StringBuilder sb = new StringBuilder();
            sb.Append(demo);

            int zahl = Convert.ToInt32(eingabe);
            Console.WriteLine($"Das doppelte der eingegebenen Zahl ist {zahl * 2}");

            throw new DivideByZeroException();
            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
