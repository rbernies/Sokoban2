using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban2.GameModel
{
    class TrapField : GameObject
    {

        private string _name;
        public int Damage = 0;

        public TrapField(string name)
        {
            _name = name;           
        }
        
        public override string name
        {
            set { _name= value; }
            get { return _name; }
        }
    }
}
