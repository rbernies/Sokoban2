using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban2
{
    public class Truck : GameObject
    {
        private string _name;

        public Truck(string name)
        {
            _name = name;
        }
       
        public override string name {
            set { name = _name; }
            get { return _name; }
        }       
    }
}