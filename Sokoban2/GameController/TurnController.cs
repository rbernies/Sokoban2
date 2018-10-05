using Sokoban2.GameModel;
using Sokoban2.GameView;
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
        UserInput userInput;
        Game game;
        bool winnable = true;

        public TurnController(BoardModel boardModel, UserInput input, Game game)
        {
            this.boardModel = boardModel;
            this.userInput = input;
            this.game = game;
        }

        public void Move()
        {
            var input = userInput.GetUserInputForGame();
            var location = boardModel.truck.Location;
            var nextTile = boardModel.truck.Location;
            var nextNextTile = boardModel.truck.Location;
            if (input.Equals("left"))
            {
                nextTile = boardModel.truck.Location.West;
                nextNextTile = boardModel.truck.Location.West.West;
            }
            else if (input.Equals("right"))
            {
                nextTile = boardModel.truck.Location.East;
                nextNextTile = boardModel.truck.Location.East.East;
            }
            else if (input.Equals("up"))
            {
                nextTile = boardModel.truck.Location.North;
                nextNextTile = boardModel.truck.Location.North.North;
            }
            else if (input.Equals("down"))
            {
                nextTile = boardModel.truck.Location.South;
                nextNextTile = boardModel.truck.Location.South.South;
            }
            if (nextTile.OccupiedBy != null && nextTile.OccupiedBy.name == "Z") {
                nextTile.OccupiedBy.name = "$";
            }
            if ((nextTile.Value.name == "." || nextTile.Value.name == "x" || nextTile.Value.name == " "
                || nextTile.Value.name == "~") && nextTile.OccupiedBy == null)
            {
                if (nextTile.Value.name == "~")
                {
                    TrapField trapField = (TrapField)nextTile.Value;
                    trapField.Damage++;
                    if (trapField.Damage >= 3)
                    {
                        trapField.name = " ";
                        winnable = false;
                    }
                }
                location.OccupiedBy = null;
                nextTile.OccupiedBy = boardModel.truck;
                boardModel.truck.Location = nextTile;
            }
            else if (nextTile.Value.name != "█" && (nextTile.OccupiedBy.name == "o" || nextTile.OccupiedBy.name == "0"))
            {

                if ((nextNextTile.Value.name == "." || nextNextTile.Value.name == "x"
                    || nextNextTile.Value.name == "~" || nextNextTile.Value.name == " ") && nextNextTile.OccupiedBy == null)
                {
                    if (nextNextTile.Value.name == "~")
                    {
                        TrapField trapField = (TrapField)nextNextTile.Value;
                        trapField.Damage++;
                        if (trapField.Damage >= 3)
                        {
                            trapField.name = " ";
                            winnable = false;
                        }
                    }
                    else if (nextTile.Value.name == "~")
                    {
                        TrapField trapField = (TrapField)nextTile.Value;
                        trapField.Damage++;
                        if (trapField.Damage >= 3)
                        {
                            trapField.name = " ";
                            winnable = false;
                        }

                    }
                    if (nextNextTile.Value.name == " ")
                    {
                        boardModel.boxList.Remove((Box)nextTile.OccupiedBy);
                        nextTile.OccupiedBy = null;
                        location.OccupiedBy = null;
                        nextTile.OccupiedBy = boardModel.truck;
                        boardModel.truck.Location = nextTile;
                        return;
                    }
                    Box box = (Box)nextTile.OccupiedBy;
                    nextTile.OccupiedBy = null;
                    nextNextTile.OccupiedBy = box;
                    box.Location = nextNextTile;

                    location.OccupiedBy = null;
                    nextTile.OccupiedBy = boardModel.truck;
                    boardModel.truck.Location = nextTile;
                }
            }

            else if (input.Equals("s"))
            {
                Console.Clear();
                game.StartGame();
            }
            else if (input.Equals("r"))
            {
                Console.Clear();
                boardModel = new BoardModel();
                game.BoardModel = boardModel;
                boardModel.MakeLevel(game.CurrentLevel);
            }
        }

        public bool WinCheck()
        {
            var list = boardModel.boxList;
            if (!winnable)
            {
                return false;
            }
            foreach (var box in list)
            {
                if (box.Location.Value.name != "x")
                {
                    return false;
                }
            }
            return true;
        }

        public void MoveEmployee()
        {
            var employee = boardModel.employee;
            Random random = new Random();
            if (employee.name == "Z" && random.Next(1, 101) < 11)
            {
                employee.name = "$";
            }
            else if (employee.name == "$" && random.Next(1, 101) < 26)
            {
                employee.name = "Z";
                return;
            }
            if (employee.name == "$")
            {
                var temp = random.Next(1, 5);
                var direction = employee.Location;
                var nextDirection = employee.Location;
                var nextNextDirection = employee.Location;
                if (temp == 1)
                {
                    direction = employee.Location.West;
                    nextDirection = employee.Location.West.West;

                    try
                    {
                        nextNextDirection = employee.Location.West.West.West;
                    }
                    catch (Exception) {
                        nextNextDirection = null;
                    }
                }
                else if (temp == 2)
                {
                    direction = employee.Location.East;
                    nextDirection = employee.Location.East.East;

                    try
                    {
                        nextNextDirection = employee.Location.East.East.East;
                    }
                    catch (Exception)
                    {
                        nextNextDirection = null;
                    }
                }
                else if (temp == 3)
                {
                    direction = employee.Location.North;
                    nextDirection = employee.Location.North.North;
                    try
                    {
                        nextNextDirection = employee.Location.North.North.North;
                    }
                    catch (Exception)
                    {
                        nextNextDirection = null;
                    }
                }
                else if (temp == 4)
                {
                    direction = employee.Location.South;
                    nextDirection = employee.Location.South.South;
                    try
                    {
                        nextNextDirection = employee.Location.South.South.South;
                    }
                    catch (Exception)
                    {
                        nextNextDirection = null;
                    }
                }

                if ((direction.Value.name == "." || direction.Value.name == "x") && direction.OccupiedBy == null)
                {
                    employee.Location.OccupiedBy = null;
                    direction.OccupiedBy = boardModel.employee;
                    boardModel.employee.Location = direction;
                }
                else if ((direction.Value.name == "." || direction.Value.name == "x")
                && (direction.OccupiedBy.name == "o" || direction.OccupiedBy.name == "0")
                && nextDirection.OccupiedBy == null && (nextDirection.Value.name == "." || nextDirection.Value.name == "x"))
                {
                    Box box = (Box)direction.OccupiedBy;
                    direction.OccupiedBy = null;
                    nextDirection.OccupiedBy = box;
                    box.Location = nextDirection;

                    boardModel.employee.Location.OccupiedBy = null;
                    direction.OccupiedBy = boardModel.employee;
                    boardModel.employee.Location = direction;
                }
                if ((direction.OccupiedBy != null && direction.OccupiedBy.name == "@") && nextDirection.OccupiedBy == null && (nextDirection.Value.name == "." || nextDirection.Value.name == "x"))
                {
                    Truck truck = (Truck)direction.OccupiedBy;
                    direction.OccupiedBy = null;
                    nextDirection.OccupiedBy = truck;
                    truck.Location = nextDirection;

                    boardModel.employee.Location.OccupiedBy = null;
                    direction.OccupiedBy = boardModel.employee;
                    boardModel.employee.Location = direction;
                }
                else if ((direction.OccupiedBy != null && direction.OccupiedBy.name == "@") && nextDirection.OccupiedBy != null
                  && nextDirection.OccupiedBy.name == "o" && (nextNextDirection.Value.name == "." || nextNextDirection.Value.name == "x"))
                {

                    Box box = (Box)nextDirection.OccupiedBy;
                    nextDirection.OccupiedBy = null;
                    nextNextDirection.OccupiedBy = box;
                    box.Location = nextNextDirection;

                    Truck truck = (Truck)direction.OccupiedBy;
                    direction.OccupiedBy = null;
                    nextDirection.OccupiedBy = truck;
                    truck.Location = nextDirection;

                    boardModel.employee.Location.OccupiedBy = null;
                    direction.OccupiedBy = boardModel.employee;
                    boardModel.employee.Location = direction;
                }

            }


        }
    }
}
