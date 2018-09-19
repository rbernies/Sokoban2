using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban2
{
   
    public class Game
    {
        Truck truck = new Truck("vrachtwaggel");
        private IDictionary<string, GameObject> test = new Dictionary<string, GameObject>();

        public Game()
        {
            test.Add("5,4", truck);
            readList();
           
          
        }

        public void readList()
        {

            Console.WriteLine(test["5,4"].name);
            Console.ReadKey();
        }

       
    }

   
}