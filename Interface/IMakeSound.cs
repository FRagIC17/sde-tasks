using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IMakeSound
    {
        void MakeSound();
    }

    public class Dog : IMakeSound
    {
        public void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }
    public class Cat : IMakeSound
    {
        public void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
    }
    public class Cow : IMakeSound
    {
        public void MakeSound()
        {
            Console.WriteLine("Moo!");
        }
    }

}
