using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban2.GameView
{
    class UserInput
    {      
        
        public string getUserInputForGame()
        {
            string result = "";
            var temp = Console.ReadKey();
           // Console.Write(temp);
            if (temp.Key == ConsoleKey.RightArrow)
            {
                result = "right";
            }
            else if (temp.Key == ConsoleKey.LeftArrow)
            {
                result = "left";
            }
            else if (temp.Key == ConsoleKey.UpArrow)
            {
                result = "up";
            }
            else if (temp.Key == ConsoleKey.DownArrow)
            {
                result = "down";
            }
            else if (temp.Key == ConsoleKey.S)
            {
                result = "s";
            }
            else if (temp.Key == ConsoleKey.D1)
            {
                result = "1";
                
            }
            else if (temp.Key == ConsoleKey.D2)
            {
                result = "2";
            }
            else if (temp.Key == ConsoleKey.D3)
            {
                result = "3";
            }
            else if (temp.Key == ConsoleKey.D4)
            {
                result = "4";
            }
            else {
                Console.WriteLine("Invalid input");
                getUserInputForGame();
            }
            
            return result;
        }
    }
}
