using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CreaturesOfTheSea
{
    static class Utility
    {

        public static int GetUserInputRange(int range)
        {
            int result = -1;
            string userInput;
            userInput = ReadLine();
            userInput = userInput.Trim();

            //this runs if the player inputs nothing.
            while (String.IsNullOrEmpty(userInput))
            {
                WriteLine("Please enter a value.");
                userInput = ReadLine();
                userInput = userInput.Trim();
            }
            int.TryParse(userInput, out result);

            if (result < 1 || result > range)
            {
                WriteLine($"Please enter a number between 1 and {range}.");
                result = GetUserInputRange(range);
            }
            return result;
        }

        public static int ShowMenu(string title, List<string> options)
        {
            WriteLine(title);

            int index = 1;
            foreach (var option in options)
            {
                WriteLine($"{index}) {option}", ConsoleColor.Green);
                index++;
            }

            int choice = Utility.GetUserInputRange(options.Count);

            return choice;
        }

    }
}
