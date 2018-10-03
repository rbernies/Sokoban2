using Sokoban2.GameController;
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
        public BoardModel BoardModel { get; set; }
        TurnController turnController;
        BoardView boardView = new BoardView();
        public int CurrentLevel { get; set; }

        public Game()
        {
            StartGame();
        }

        public void StartGame()
        {
            Console.Clear();
            BoardModel = new BoardModel();
            turnController = new TurnController(BoardModel, input, this);
            welcome.DisplayWelcomeScreen();
            string userInput = input.GetUserInputForGame();
            if (userInput.Equals("s"))
            {
                Environment.Exit(1);
            }
            else if (userInput.Equals("1") || userInput.Equals("2") || userInput.Equals("3") 
                || userInput.Equals("4") || userInput.Equals("5") || userInput.Equals("6"))
            {
                CurrentLevel = int.Parse(userInput);
                BoardModel.MakeLevel(CurrentLevel);
                boardView.PrintLevel(BoardModel.BoardList);
                RunGame();
            }
            else
            {
                StartGame();
            }        
        }

        public void RunGame()
        {
            while (true)
            {
                turnController.Move();
                boardView.PrintLevel(BoardModel.BoardList);
                if (turnController.WinCheck())
                {
                    Console.WriteLine("Gefeliciteerd! Druk op een toets om terug te gaan naar het menu.");
                    Console.ReadKey();
                    StartGame();
                }
            }
        }      
    }
}