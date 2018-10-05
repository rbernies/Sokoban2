using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban2.GameModel
{
    class BoardModel
    {
        Dictionary<Point, GameObject> currentBoard;
        Dictionary<Point, GameObject> originalBoard;

        FileReader fileReader = new FileReader();

        public void generateLevel(int level) {
            currentBoard = fileReader.LoadObjectDictionary(level);
            originalBoard = fileReader.LoadObjectDictionary(level);
            foreach (var item in originalBoard) {
                if (item.Value.name == "Truck" || item.Value.name == "Box") {
                    originalBoard[item.Key] = new EmptyField("EmptyField");
                }
            }
        }

        public Dictionary<Point, GameObject> getCurrentBoard()
        {
            return currentBoard;
        }
    }
}
