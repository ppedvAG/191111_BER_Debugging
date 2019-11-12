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

            List<Person> allePersonen = new List<Person>();
            for (int i = 0; i < 10_000_000; i++)
            {
                Random r = new Random();

                Person p = new Person();
                p.Vorname = Guid.NewGuid().ToString();
                p.Nachname = Guid.NewGuid().ToString();
                p.Alter = (byte)r.Next(0, 255);
                p.Kontostand = r.Next(Int32.MinValue,Int32.MaxValue);

                allePersonen.Add(p);
            }

            Console.WriteLine("Alle Personen wurden erstellt ...");

            Console.WriteLine("Suche nach der Person mit dem höchsten Kontostand");

            Person aktuellReichstePerson = null;
            foreach (var item in allePersonen)
            {
                if(aktuellReichstePerson == null)
                {
                    aktuellReichstePerson = item;
                    continue;
                }

                if (aktuellReichstePerson.Kontostand < item.Kontostand)
                    aktuellReichstePerson = item;
            }

            Console.WriteLine($"Die reichste Person ist: {aktuellReichstePerson.Vorname} {aktuellReichstePerson.Nachname} mit einem Kontostand von {aktuellReichstePerson.Kontostand}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }

    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }
    }

}
