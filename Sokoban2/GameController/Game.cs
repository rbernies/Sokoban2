using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban2
{
   
    public class Game
    {
        private IDictionary<string, string> test = new Dictionary<string, string>();

        public Game()
        {
            test.Add("5,4", "wall");
            readList();
        }

        public void readList()
        {
            Console.WriteLine(test["5,4"]);
            Console.ReadKey();
        }


    }

   
}