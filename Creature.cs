using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaturesOfTheSea
{
    public class Creature
    {

        public string Name { get; set; }

        public string Color { get; set; }

        public int Age { get; set; }

        public Creature()
        {
            
        }

        public Creature(string name, int age, string color)
        {
            Name = name;
            Age = age;
            Color = color;
        }

        public virtual void Eat()
        {
            Console.WriteLine($"{Name} Creature EAT");
        }

        public virtual void Eat(Item item)
        {
            Console.WriteLine($"{Name} Creature EAT");
        }

        public void Communicate()
        {
            Console.WriteLine($"{Name} says hi");
        }

    }
}
