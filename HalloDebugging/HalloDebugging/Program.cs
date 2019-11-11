﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

                Thread.Sleep(150);
                Console.WriteLine(i);

                // Breakpoint im Code
                // if (i == 50)
                //    Debugger.Break();

                //if (i == 80)
                //    throw new DivideByZeroException();
            }
            Console.WriteLine("ABCDE");


            Console.WriteLine("---ENDE---");

            Console.WriteLine("ZYX");


            // .pdb - Datei:
            // Wird bei jedem kompilieren erstellt und beinhaltet Informationen über die aktuelle Anwendung
            
            // Mit .pdb: Callstack + Zeilennummer + Codefenster in VisualStudio beim Remote-Debugger
            // Ohne .pdb: Callstack
            // => pdb-Dateien auf einem Symbolserver (z.B. im eigenen TFS) hochladen
            MachEtwasKapput1();

            // .NET Framework - Debugging:
            // https://referencesource.microsoft.com/

            // Falls beim Debuging von z.B. "Console.WriteLine" die Datei "console.cs" angefordert wird:
            // von "referencesource.microsoft.com" die datei "console.cs" herunterladen und abspeichern

            Console.ReadKey();
        }

        private static void MachEtwasKapput1()
        {
            MachEtwasKapput_JETZT();
        }

        private static void MachEtwasKapput_JETZT()
        {
            throw new StackOverflowException();
        }

        public static int Addieren(int z1,int z2)
        {
            return z1 + z2;
        }

    }
}
