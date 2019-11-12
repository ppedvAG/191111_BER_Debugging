using HalloEntityFramework.NeuesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            // Entity Framework: DatabaseFirst
            // Anleitung:
            // 1) NewItem > Ado.NET EntityFramwork Model
            // 2) Entity Framework Code First DatabaseFirst auswählen
            // 3) Connection auswählen und die Tabellen der DB auswählen

            Model1 meinModel = new Model1();

            // Daten auslesen
            var alleCustomers = meinModel.Customers.ToList();
            foreach (var item in alleCustomers)
            {
                Console.WriteLine($"{item.CompanyName}");
            }

            Customers neuerCustomer = new Customers();
            neuerCustomer.ContactName = "Michael Zöhling";
            neuerCustomer.CompanyName = "ppedv AG";
            neuerCustomer.CustomerID = "MZ200";
            // Insert:
            // meinModel.Customers.Add(neuerCustomer);

            // Speichern (automatisch in einer Transaktion)
            // meinModel.SaveChanges();

            // Abfragequery ausgeben:
            Console.WriteLine(meinModel.Customers.Where(x => x.CustomerID == "MZ200"));

            // Komplexes LINQ:

            var query = meinModel.Employees.Where(x => x.HireDate < DateTime.Now)
                                           .OrderBy(x => x.LastName)
                                           .Take(5);

            Console.WriteLine(query);

            // StoredProc von EF DatabaseFirst Designer -> Generiert
            NorthwindEntities model2 = new NorthwindEntities();
            var result = model2.GetEmployees(); // StoredProc aufrufen

            

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
