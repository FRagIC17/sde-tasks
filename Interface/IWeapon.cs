using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal interface IWeapon
    {
        public int Attack();
    }

    public class Sword : IWeapon
    {
        public int Attack()
        {
            int damage = 10; 
            Console.WriteLine($"Swinging the sword, hits for {damage} damage!");
            return damage;

        }
    }

    public class Bow : IWeapon
    {
        Random random = new Random();
        public int Attack()
        {
            int damage = random.Next(5, 15);
            Console.WriteLine($"Shooting an arrow, hits for {damage} damage!");
            return damage;
        }
    }

    public class Staff : IWeapon
    {
        int MagicPower = 20;
        public int Attack()
        {
            Console.WriteLine($"Casting a spell with the staff, hits for {MagicPower} magic damage!");
            return MagicPower;
        }
    }
}
