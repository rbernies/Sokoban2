using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban2
{
    public class Box : GameObject
    {
        private string _name;

        public Box(string name)
        {
            _name = name;
        }

        public override string name
        {
            set { name = _name; }
            get { return _name; }
        }
    }
}