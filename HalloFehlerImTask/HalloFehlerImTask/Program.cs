using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            #region Threads
            //Thread t1 = new Thread(MachWasInEinemThread);
            //Thread t2 = new Thread(MachWasInEinemThread2);
            //Thread t3 = new Thread(MachWasInEinemThread3);


            //t1.Start();
            //t2.Start();
            //t3.Start(); 
            #endregion

            #region Task - Grundlagen
            // Ab mindestens .NET Framework 4.0 (4.5 wäre besser wegen async/await)

            //Task t1 = new Task(MachWasInEinemThread);
            //t1.Start();

            //Task t2 = Task.Run(MachWasInEinemThread2); // Startet sofort
            //Task t3 = Task.Factory.StartNew(MachWasInEinemThread3); // Startet sofort

            //// Abfragen ob ein Task fertig ist:

            //if (t1.IsCompleted == true)
            //    ; // fertig
            //if (t1.IsFaulted == true)
            //    ;// Fehler im Task
            //if (t1.IsCanceled == true)
            //    ; // task wurde abgebrochen


            //// Task mit einem Fehler:
            //Task t4 = Task.Run(TaskMitEinemFehler);

            //Thread.Sleep(5000);
            //if(t4.IsFaulted)
            //    Console.WriteLine("Es gab einen Fehler im Task 4");
            //else
            //    Console.WriteLine("Task 4 ist ok");

            //// Auf Fehler draufkommen:

            //Task t5 = Task.Run(TaskMitEinemFehler2);

            ////Task.WaitAll(t1, t2, t3, t4); // Programm bleibt stehen bis alle Fertig sind
            ////Task.WaitAny(t1, t2, t3, t4); // Programm bleibt stehen einer von den Tasks fertig ist

            //t5.Wait(); // Warten bis Task5 fertig ist
            #endregion

            #region Aggregate-Exception
            //Task t1 = Task.Run(() => throw new DivideByZeroException());
            //Task t2 = Task.Run(() => throw new FormatException());
            //Task t3 = Task.Run(() => throw new StackOverflowException());

            //try
            //{
            //    Task.WaitAll(t1, t2, t3);
            //}
            //catch (AggregateException ex) // Container, der alle Exceptions die "gleichzeitig" passieren können, zusammenfasst
            //{

            //    throw;
            //} 
            #endregion


            int[] durchgänge = { 1_000, 10_000, 50_000, 100_000, 250_000, 500_000, 1_000_000, 5_000_000, 10_000_000 };

            Stopwatch watch = new Stopwatch();

            // Nur dazu da, damit der Compiler schon mal alles erstellt hat
            ForSchleife(100);
            ParallelSchleife(100);

            for (int i = 0; i < durchgänge.Length; i++)
            {
                Console.WriteLine($"-----------------Durchgang {durchgänge[i]} ---------------------");

                watch.Restart();
                ForSchleife(durchgänge[i]);
                watch.Stop();
                Console.WriteLine($"For: {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                ParallelSchleife(durchgänge[i]);
                watch.Stop();
                Console.WriteLine($"Parallel: {watch.ElapsedMilliseconds}ms");
            }

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }






        public static void ForSchleife(int durchgänge)
        {
            double[] data = new double[durchgänge];
            for (int i = 0; i < durchgänge; i++)
            {
                data[i] = i % (Math.Abs(i) * Math.E +(Math.Pow(i, 0.3333333333) * Math.Sin(i * 50) - Math.Sqrt(Math.Exp(i + 1))) / Math.Sin(i));
            }
        }

        public static void ParallelSchleife(int durchgänge)
        {
            double[] data = new double[durchgänge];
            // Parallel.For(0, durchgänge,new ParallelOptions { MaxDegreeOfParallelism = 4 }, i =>
            Parallel.For(0, durchgänge, i =>
            {
                data[i] = i % (Math.Abs(i) * Math.E + (Math.Pow(i, 0.3333333333) * Math.Sin(i * 50) - Math.Sqrt(Math.Exp(i + 1))) / Math.Sin(i));
            });
        }









        private static void TaskMitEinemFehler2()
        {
            Thread.Sleep(5000);
            throw new StackOverflowException();
        }

        private static void TaskMitEinemFehler()
        {
            Thread.Sleep(3000);
            throw new DivideByZeroException();
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
