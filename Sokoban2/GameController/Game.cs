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
        BoardModel board = new BoardModel();
        BoardView boardView = new BoardView();

        public Game()
        {
            welcome.displayWelcomeScreen();
            board.generateLevel(input.getUserInputForLevel());
            boardView.printBoard(board.getCurrentBoard());
        }        

        public void runGame()
        {
            // vraag user input
            // kijk of zet mogelijk is (deze methode gaat net zolang door totdat er een valide zet is gedaan)
            // teken view opnieuw
            // doe de win check
            // gewonnen = S voor terug naar home scherm
            // niet gewonnen = opnieuw de runGame methode
     
        }
    }  
}