using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban2
{
    public class EmptyField : GameObject
    {
        private string _name;

        public EmptyField   (string name)
        {
            int test;
            _name = name;
        }

        public override string name
        {
            set { name = _name; }
            get { return _name; }
        }
    }
}