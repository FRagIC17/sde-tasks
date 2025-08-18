using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal interface IPrintable
    {
        void Print();
    }

    public class Invoice : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Printing Invoice...");
        }
    }

    public class Report : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Printing Report...");
        }
    }

    public class Letter : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Printing Letter...");
        }
    }
}
