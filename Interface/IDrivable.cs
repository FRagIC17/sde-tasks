using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IDrivable
    {
        public void Start();
        public void Stop();

    }

    public class Vehicle
    {
        string Brand { get; set; }
    }

    public class Car : Vehicle, IDrivable
    {
        public void Start()
        {
            Console.WriteLine("Car is starting.");
        }
        public void Stop()
        {
            Console.WriteLine("Car is stopping.");
        }
    }

    public class Motorcycle : Vehicle, IDrivable
    {
        public void Start()
        {
            Console.WriteLine("Motorcycle is starting.");
        }
        public void Stop()
        {
            Console.WriteLine("Motorcycle is stopping.");
        }
    }
}
