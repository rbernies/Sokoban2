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
        Board board = new Board();

        public Game()
        {
            welcome.displayWelcomeScreen();           
            board.makeLevel(input.getUserInputForLevel());
        }            
    }  
}