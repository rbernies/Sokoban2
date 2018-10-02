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
        BoardModel boardModel;
        TurnController turnController;
        BoardView boardView = new BoardView();
        int currentLevel;
        public Game()
        {
            StartGame();
            //   board.generateLevel(input.getUserInputForLevel());
            //   turnController = new TurnController(board);
        }

        public void StartGame()
        {
            boardModel = new BoardModel();
            welcome.displayWelcomeScreen();
            var userInput = input.getUserInputForGame();
            if (userInput.Equals("s"))
            {
                Environment.Exit(1);
            }
            else {
                currentLevel = int.Parse(userInput);
                boardModel.MakeLevel(currentLevel);
                
            }
            boardView.PrintLevel(boardModel.BoardList);
            RunGame();
        }

        public void RunGame()
        {
            while (true)
            {
                Move();
                boardView.PrintLevel(boardModel.BoardList);
                if (WinCheck()) {
                    Console.WriteLine("Gefeliciteerd! Druk op een toets om terug te gaan naar het menu.");
                    Console.ReadKey();
                    Console.Clear();
                    StartGame();
                }
            }
        }

        public void Move()
        {
            var dir = input.getUserInputForGame();
            var location = boardModel.truck.Location;
            if (dir.Equals("right"))
            {
                if ((location.East.Value.name == "." || location.East.Value.name == "x") && location.East.OccupiedBy == null)
                {
                    location.OccupiedBy = null;
                    location.East.OccupiedBy = boardModel.truck;
                    boardModel.truck.Location = location.East;
                }
                else if (location.East.Value.name != "█" && (location.East.OccupiedBy.name == "o" || location.East.OccupiedBy.name == "0"))
                {
                    if ((location.East.East.Value.name == "." || location.East.East.Value.name == "x") && location.East.East.OccupiedBy == null)
                    {
                        Box box = (Box)location.East.OccupiedBy;
                        location.East.OccupiedBy = null;
                        location.East.East.OccupiedBy = box;
                        box.Location = location.East.East;

                        location.OccupiedBy = null;
                        location.East.OccupiedBy = boardModel.truck;
                        boardModel.truck.Location = location.East;
                    }
                }
            }
            else if (dir.Equals("left"))
            {
                if ((location.West.Value.name == "." || location.West.Value.name == "x") && location.West.OccupiedBy == null)
                {
                    location.OccupiedBy = null;
                    location.West.OccupiedBy = boardModel.truck;
                    boardModel.truck.Location = location.West;
                }
                else if (location.West.Value.name != "█" && (location.West.OccupiedBy.name == "o" || location.West.OccupiedBy.name == "0"))
                {
                    if ((location.West.West.Value.name == "." || location.West.West.Value.name == "x") && location.West.West.OccupiedBy == null)
                    {
                        Box box = (Box)location.West.OccupiedBy;
                        location.West.OccupiedBy = null;
                        location.West.West.OccupiedBy = box;
                        box.Location = location.West.West;

                        location.OccupiedBy = null;
                        location.West.OccupiedBy = boardModel.truck;
                        boardModel.truck.Location = location.West;
                    }
                }

            }
            else if (dir.Equals("up"))
            {

                if ((location.North.Value.name == "." || location.North.Value.name == "x") && location.North.OccupiedBy == null)
                {
                    location.OccupiedBy = null;
                    location.North.OccupiedBy = boardModel.truck;
                    boardModel.truck.Location = location.North;
                }
                else if (location.North.Value.name != "█" && (location.North.OccupiedBy.name == "o" || location.North.OccupiedBy.name == "0"))
                {
                    if ((location.North.North.Value.name == "." || location.North.North.Value.name == "x") && location.North.North.OccupiedBy == null)
                    {
                        Box box = (Box)location.North.OccupiedBy;
                        location.North.OccupiedBy = null;
                        location.North.North.OccupiedBy = box;
                        box.Location = location.North.North;

                        location.OccupiedBy = null;
                        location.North.OccupiedBy = boardModel.truck;
                        boardModel.truck.Location = location.North;
                    }
                }

            }
            else if (dir.Equals("down"))
            {
                if ((location.South.Value.name == "." || location.South.Value.name == "x") && location.South.OccupiedBy == null)
                {
                    location.OccupiedBy = null;
                    location.South.OccupiedBy = boardModel.truck;
                    boardModel.truck.Location = location.South;
                }
                else if (location.South.Value.name != "█" && (location.South.OccupiedBy.name == "o" || location.South.OccupiedBy.name == "0"))
                {
                    if ((location.South.South.Value.name == "." || location.South.South.Value.name == "x") && location.South.South.OccupiedBy == null)
                    {
                        Box box = (Box)location.South.OccupiedBy;
                        location.South.OccupiedBy = null;
                        location.South.South.OccupiedBy = box;
                        box.Location = location.South.South;

                        location.OccupiedBy = null;
                        location.South.OccupiedBy = boardModel.truck;
                        boardModel.truck.Location = location.South;
                    }
                }
            }
            else if (dir.Equals("s")) {
                Console.Clear();
                StartGame();
            }
            else if (dir.Equals("r"))
            {
                Console.Clear();
                boardModel = new BoardModel();
                boardModel.MakeLevel(currentLevel);
            }
        }

        public bool WinCheck() {
            var list = boardModel.boxList;
            foreach (var box in list) {
                if (box.Location.Value.name != "x") {
                    return false;
                }
            }
            return true;
        }
    }
}