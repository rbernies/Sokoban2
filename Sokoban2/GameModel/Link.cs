using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban2.GameModel
{
    public class Link
    {
        public Link North { get; set; }
        public Link East { get; set; }
        public Link South { get; set; }
        public Link West { get; set; }
        public GameObject Value { get; set; }
        public GameObject OccupiedBy { get; set; }

        public Link() {
            
        }


    }
}
