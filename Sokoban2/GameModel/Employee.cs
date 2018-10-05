using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban2.GameModel
{
    public class Employee : GameObject
    {

        private string _name;
        public Link Location { get; set; }

        public Employee(string name, Link location)
        {
            Location = location;
            _name = name;
        }

        public override string name
        {
            set { _name = value; }
            get { return _name; }
        }
    }
}
