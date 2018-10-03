using Sokoban2.GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban2.GameView
{
    class BoardView
    {
     
        public void PrintLevel(LinkedList board)
        {
            Console.Clear();
            Console.WriteLine("┌──────────┐");
            Console.WriteLine("| Sokoban  |");
            Console.WriteLine("└──────────┘");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");

            Link currentLink = board.First;
            Link line = board.First;
            while (true)
            {
                if (currentLink.Value == null)
                {
                    Console.Write(" ");
                }
                else if (currentLink.OccupiedBy != null)
                {
                    if (currentLink.Value.name == "x" && currentLink.OccupiedBy.name == "o") {
                        Console.Write("0");
                    } else
                    Console.Write(currentLink.OccupiedBy.name);

                }
                else {
                    Console.Write(currentLink.Value.name);
                }
                if (currentLink.East == null)
                {
                    currentLink = line.South;
                    line = line.South;
                    Console.WriteLine();
                }
                else
                {
                    currentLink = currentLink.East;
                }
                if (board.Last == currentLink)
                {
                    if (currentLink.Value == null)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(currentLink.Value.name);
                    }
                    break;
                }
            }
            Console.WriteLine("");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("> gebruik pijljestoetsen (s = stop, r = reset)");
        }
    }
}
