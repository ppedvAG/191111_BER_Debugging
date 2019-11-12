using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloPerformanceProfiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Personen werden erstellt ...");

            List<Person> allePersonen = new List<Person>(10_000_000); // variante 1
            // Variante 2: gleich ein Array nehmen, wenn die größe bekannt ist
            Random r = new Random();

            Parallel.For(0, 10_000_000, i =>
             {
                 Person p = new Person();
                 p.Vorname = string.Empty; //Guid.NewGuid().ToString();
                 p.Nachname = string.Empty; //Guid.NewGuid().ToString();
                 p.Alter = (byte)r.Next(0, 255);
                 p.Kontostand = r.Next(Int32.MinValue, Int32.MaxValue);

                 allePersonen.Add(p);
             });

            Console.WriteLine("Alle Personen wurden erstellt ...");

            Console.WriteLine("Suche nach der Person mit dem höchsten Kontostand");

            Person aktuellReichstePerson = new Person(); // leeres Struct
            foreach (var item in allePersonen)
            {
                if (aktuellReichstePerson.Kontostand < item.Kontostand)
                    aktuellReichstePerson = item;
            }

            Console.WriteLine($"Die reichste Person ist: {aktuellReichstePerson.Vorname} {aktuellReichstePerson.Nachname} mit einem Kontostand von {aktuellReichstePerson.Kontostand}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }

    public struct Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }
    }

}
