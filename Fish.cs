using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaturesOfTheSea
{
    public class Fish : Creature
    {
        public int NumberOfFins { get; set; }
        //public Fish(string name, int age, string color)
        //{
        //    Name = name;
        //    Age = age;
        //    Color = color;
        //}

        //public override void Eat()
        //{
        //    Console.WriteLine($"{Name} FISH EAT");
        //}

        public override void Eat(Item item)
        {
            //Checking the type 
            if (item is SeaWeed)
            {
                Console.WriteLine($"{Name} Creature is eating {item.Name}");
            }
            else
            {
                Console.WriteLine($"Sorry {Name} Creature only eats food. {item.Name} is not food");
            }
        }

        
    }
}
