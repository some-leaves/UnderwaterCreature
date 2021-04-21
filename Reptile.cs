using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaturesOfTheSea
{
    public class Reptile : Creature
    {
        public bool HasTail { get; set; }


        

        public override void Eat()
        {
            Console.WriteLine($"{Name} eats with a fork");
        }

        public void ReptileEat()
        {
            Console.WriteLine($"{Name} eats with a fork");
        }
    }
}
