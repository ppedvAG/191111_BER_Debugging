using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            // F5:      Starten mit Debugger
            // STRG+F5: Starten ohne Debugger

            // F10:     Einzelschritt ohne Hineinspringen in Methoden
            // F11:     Einzelschritt mit Hineinspringen in Methoden
            Console.WriteLine("Hallo Welt");

            int erg = Addieren(12, 5);

            Console.WriteLine(erg);

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        public static int Addieren(int z1,int z2)
        {
            return z1 + z2;
        }

    }
}
