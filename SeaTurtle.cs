using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaturesOfTheSea
{
    public class SeaTurtle : Reptile
    {
        public override void Eat(Item item)
        {
            //Checking the type 
            if (item is Algae)
            {
                Console.WriteLine($"{Name} is eating {item.Name}");
            }
            else
            {
                Console.WriteLine($"Sorry {Name} only eats algae. {item.Name} is not algae");
            }
        }
    }
}
