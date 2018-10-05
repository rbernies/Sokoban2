using Sokoban2.GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban2
{
    public class Truck : GameObject
    {
        private string _name;
        public Link Location { get; set; }
        public Truck(string name,Link location)
        {
            _name = name;
            Location = location;
        }
       
        public override string name {
            set { name = _name; }
            get { return _name; }
        }       
    }
}