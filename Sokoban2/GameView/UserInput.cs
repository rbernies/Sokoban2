using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban2.GameView
{
    class UserInput
    {

        public int getUserInputForLevel()
        {
           int result = 0;
           var temp = Console.ReadKey();
            if (temp.Key == ConsoleKey.D1)
            {
                result = 1;
                return result;
            }
            if (temp.Key == ConsoleKey.D2)
            {
                result = 2;
                return result;
            }
            if (temp.Key == ConsoleKey.D3)
            {
                result = 3;
                return result;
            }
            if (temp.Key == ConsoleKey.D4)
            {
                result = 4;
                return result;
            } else
            {
                Console.WriteLine("Please enter a number between 1-4 to select a level or press 's' to exit");
                getUserInputForLevel();
            }
            return result;
        }        
        
        public string getUserInputForGame()
        {
            string result = "";
            var temp = Console.ReadKey();
            Console.Write(temp);
            if (temp.Key == ConsoleKey.RightArrow)
            {
                result = "right";
            }
            if (temp.Key == ConsoleKey.LeftArrow)
            {
                result = "left";
            }
            if (temp.Key == ConsoleKey.UpArrow)
            {
                result = "up";
            }
            if (temp.Key == ConsoleKey.DownArrow)
            {
                result = "down";
            }
            return result;
        }
    }
}
