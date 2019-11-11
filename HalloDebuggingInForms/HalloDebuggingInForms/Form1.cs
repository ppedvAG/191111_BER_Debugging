using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalloDebuggingInForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Person> personen = new List<Person>();
            for (int i = 0; i < 500; i++)
            {
                Trace.WriteLine($"Trace: {i}");
                personen.Add(new Person());
                personen.Add(new Person());
                personen.Add(new Person());

                Thread.Sleep(50);
                if (i == 499)
                    throw new DivideByZeroException();
            }
        }
    }

    class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }
}
