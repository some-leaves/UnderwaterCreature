using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CreaturesOfTheSea
{
    public class Game
    {

        public List<Creature> Creatures { get; set; }

        public List<Item> Items { get; set; }


        public string fileLocation = "C:\\Work\\Temp\\CreaturesOfTheSea.txt";

        public Game()
        {

            SeaWeed seeWeed = new SeaWeed()
            {
                Name = "Sea Weed"
            };

            Food fishFood = new Food()
            {
                Name = "Fish Food",
                Calories = 10
            };

            Algae algae = new Algae()
            {
                Name = "Algae",
                Calories = 45
            };

            Goldfish swimShady = new Goldfish()
            {
                Name = "Swim Shady",
                Age = 1,
                Color = "Orange",
                NumberOfFins = 1
            };

            Pufferfish phat = new Pufferfish()
            {
                Name = "Phat",
                Age = 7,
                Color = "Yellow",
                NumberOfFins = 5
            };

            SeaTurtle crush = new SeaTurtle()
            {
                Name = "Crush",
                Age = 150,
                Color = "Green",
                HasTail = true
            };

            Reptile waterDragon = new Reptile()
            {
                Name = "Mr Dragon",
                Age = 2,
                Color = "Green",
                HasTail = true
            };


            Creatures = new List<Creature>()
            {
                swimShady,
                phat,
                crush,
                waterDragon
            };

            Items = new List<Item>()
            {
                fishFood,
                algae,
                seeWeed
            };

            //List<Creature> creaturesThatAreGreen = new List<Creature>();
            //foreach (Creature creature in Creatures)
            //{
            //    if (creature.Color == "Green" && creature.Age > 100)
            //    {
            //        creaturesThatAreGreen.Add(creature);
            //    }
            //}
            //WriteLine(creaturesThatAreGreen.Count);

            //List<Creature> creaturesThatAreGreen2 = Creatures.Where(creature => creature.Color == "Green" && creature.Age > 100).ToList();

            //WriteLine(creaturesThatAreGreen2.Count);


            //Creature crush = Creatures.FirstOrDefault(creature => creature.Name == "Crush");

            List<string> Options = new List<string>()
            {
                "List all creatures",
                "List all items",
                "Select a creature",
                "Create a new creature",
                "Exit game"
            };

            //Checking to see if the text file exists
            if (File.Exists(fileLocation))
            {
                //Read all contents
                //Read all contents from the file
                var lines = File.ReadLines(fileLocation);

                foreach (string line in lines)
                {
                    //NAME%AGE%COLOR - this is the file format
                    string[] values = line.Split("%");

                    //Make sure name is not empty
                    if (values.Length == 3 && !String.IsNullOrEmpty(values[0]))
                    {
                        //Assing the first part of the string to the name
                        string name = values[0];
                        //Assign second part as age
                        int age = Convert.ToInt32(values[1]);

                        //Assign third part as color
                        string color = values[2];

                        Creature creature = new Creature()
                        {
                            Name = name,
                            Age = age,
                            Color = color
                        };
                        Creatures.Add(creature);
                    }
                }
            }
            else
            {
                //Creating an empty text file
                File.WriteAllText(fileLocation, "");
            }

            //string text =
            //"A class is the most powerful data type in C#. Like a structure, " +
            //"a class defines the data and behavior of the data type. ";

            //await File.WriteAllTextAsync("WriteText.txt", text);

            bool exit = false;
            while (!exit)
            {
                int userChoice = Utility.ShowMenu("Please choose an option:", Options);
                switch (userChoice)
                {
                    case 1:
                        ShowCreatureList();
                        break;
                    case 2:
                        ShowItemsList();
                        break;
                    case 3:
                        SelectACreature();
                        break;
                    case 4:
                        CreateNewCreature();
                        break;
                    case 5:
                        exit = true;
                        WriteLine("Thank you for playing");
                        break;
                    default:
                        break;
                }
            }
        }

        private void CreateNewCreature()
        {
            Creature creature = new Creature();
            WriteLine("What would you like to call the creature?");
            creature.Name = ReadLine();
            WriteLine($"How old is {creature.Name}?");
            creature.Age = Utility.GetUserInputRange(200);
            WriteLine($"What color is {creature.Name}?");
            creature.Color = ReadLine();

            Creatures.Add(creature);

            //Creating 1 line of string out of the creature information. Information seperated by a semi column so that it can parsed easly later on.
            string creatureDetails = $"{creature.Name}%{creature.Age}%{creature.Color}";
            //Updating text file with new create information
            using (StreamWriter sw = File.AppendText(fileLocation))
            {
                sw.WriteLine(creatureDetails);
            }
        }

        private void SelectACreature()
        {
            //Language Integrated Query(LINQ)

            //WriteLine(crush.Age);
            List<string> creatureList = Creatures.Select(creature => creature.Name).ToList();
            int creatureChoice = Utility.ShowMenu("Please choose a creature", creatureList);

            Creature selectedCreature = Creatures[creatureChoice - 1];
            List<string> Options = new List<string>()
            {
                $"Feed {selectedCreature.Name}",
                $"Talk to {selectedCreature.Name}",
                "Go back"
            };

            bool exit = false;
            while (!exit)
            {
                int subMenuChoice = Utility.ShowMenu($"{selectedCreature.Name} says hi! What would you like to do?", Options);
                switch (subMenuChoice)
                {
                    case 1:
                        Random random = new Random();
                        int index = random.Next(0, Items.Count);
                        //WriteLine($"Random: {index}");
                        selectedCreature.Eat(Items[index]);
                        break;
                    case 2:
                        selectedCreature.Communicate();
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }

        }

        private void ShowCreatureList()
        {
            foreach (Creature creature in Creatures)
            {
                WriteLine($"{creature.Name} is {creature.Age} years old, and is the color {creature.Color}");
            }
        }
        private void ShowItemsList()
        {
            foreach (Item item in Items)
            {
                WriteLine($"{item.Name}");
            }
        }


    }
}
