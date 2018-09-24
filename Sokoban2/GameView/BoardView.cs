using Sokoban2.GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban2.GameView
{
    class BoardView
    {
        public int makeLevel(string result)
        {
            int level = 0;
            Console.WriteLine("hi");
            Console.ReadKey();
            if(result == "1" || result == "2" || result == "3" || result == "4") {
                level = Convert.ToInt32(result);
            }            
            return level;
        }
        
        public void printLevel(int level)
        {

        }
    }
}
