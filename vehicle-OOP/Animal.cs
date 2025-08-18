using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicle_OOP
{
    
    public abstract class Animal
    {
        public string Name { get; set; }
        abstract public void MakeSound();
    }

    public class Lion : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("RAWR!");
        }
    }

    public class Elephant : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("elephant noise!");
        }
    }

    public class Parrot : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("clicking sounds!");
        }
    }
}
