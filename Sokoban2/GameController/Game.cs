using Sokoban2.GameModel;
using Sokoban2.GameView;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban2
{
   
    public class Game
    {
        WelcomeScreen welcome = new WelcomeScreen();
        UserInput input = new UserInput();
        BoardView board = new BoardView();
        FileReader fileReader = new FileReader();
        BoardModel boardModel = new BoardModel();
        public Game()
        {
            welcome.displayWelcomeScreen();
            //   board.makeLevel(input.getUserInputForLevel());
        }

        public void loadLevel() {
            int level = input.getUserInputForLevel();
            boardModel.GenerateTiles(fileReader.LoadObjectDictionary(level));
        }
    }  
}