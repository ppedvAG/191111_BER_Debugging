using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalloFehlerImTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(MachWasInEinemThread);
            Thread t2 = new Thread(MachWasInEinemThread2);
            Thread t3 = new Thread(MachWasInEinemThread3);


            t1.Start();
            t2.Start();
            t3.Start();


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void MachWasInEinemThread()
        {
            for (int i = 0; i < 300; i++)
            {
                Thread.Sleep(100);
                Console.Write("#");
            }
        }
        private static void MachWasInEinemThread2()
        {
            for (int i = 0; i < 300; i++)
            {
                Thread.Sleep(80);
                Console.Write("_");
            }
        }

        private static void MachWasInEinemThread3()
        {
            for (int i = 0; i < 300; i++)
            {
                Thread.Sleep(50);
                Console.Write("X");
            }
        }
    }
}
