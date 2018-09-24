using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban2.GameModel
{
    class BoardModel
    {
        public List<Tile> board;

        public BoardModel() {

        }

        public void GenerateTiles(Dictionary<Point, GameObject> dictionary) {
            foreach (var item in dictionary) {
               board.Add( new Tile(null, null, null, null, item.Value));
               
            }
        }

    }
}
