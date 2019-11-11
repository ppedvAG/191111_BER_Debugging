﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                // Breakpoints mit Condition: Rechtsklick auf Breakpoint -> Condition
                // Features:
                // Breakpoint mit Condition (z.B. i == 99)
                // Breakpoint nach z.B. 10 Aufrufen ( = und >=)
                // Breakpoint bei z.B. jedem 3ten Aufruf (Multiple of)
                
                // Breakpoint-Fenster Debug > Windows > Breakpoints
                // Breakpoints sind Exportier- und Importierbar
                Console.WriteLine(i);

                // Breakpoint im Code
                // if (i == 50)
                //    Debugger.Break();

                if (i == 80)
                    throw new DivideByZeroException();
            }
            Console.WriteLine("ABCDE");


            Console.WriteLine("---ENDE---");

            Console.WriteLine("ZYX");


            Console.ReadKey();
        }

        public static int Addieren(int z1,int z2)
        {
            return z1 + z2;
        }

    }
}
