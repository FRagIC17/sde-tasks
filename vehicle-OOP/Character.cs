using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicle_OOP
{
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public int Attack()
        {
            int damage = 10;
            return damage;
        }
    }

    public class Warrior : Character
    {
        public int Strength { get; set; }

        public Warrior(string name, int health, int strength)
        {
            Name = name;
            Health = health;
            Strength = strength;
        }
        public int Attack()
        {
            return Strength * 2;
        }
    }

    public class Mage : Character
    {
        public int Mana { get; set; }

        public Mage(string name, int health, int mana)
        {
            Name = name;
            Health = health;
            Mana = mana;
        }

        public int Attack()
        {
            return Mana / 2;
        }
    }

}
