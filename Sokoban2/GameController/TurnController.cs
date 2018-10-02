using Sokoban2.GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban2.GameController
{
    class TurnController
    {
        BoardModel boardModel;
        public TurnController(BoardModel boardmodel) {
            boardModel = boardmodel;
        }
        public void CanMove(string dir) {
            int playerX;
            int playerY;
           /* foreach (var item in boardModel.currentBoard) {
                if (item.Value.name == "Truck") {
                    playerX = item.Key.X;
                    playerY = item.Key.Y;
                    break;
                }
            }*/

            if (dir == "right") {
                    
            }
            else if (dir == "left")
            {

            }
            else if (dir == "up")
            {

            }
            else if (dir == "down")
            {

            }
        }
    }
}
