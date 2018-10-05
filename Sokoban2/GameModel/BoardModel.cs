using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban2.GameModel
{
    public class BoardModel
    {
        public LinkedList BoardList { get; }
        public Truck truck;
        public List<Box> boxList = new List<Box>();
        public Employee employee;
        public BoardModel()
        {
            BoardList = new LinkedList();
        }

        public void MakeLevel(int level)
        {
            string text = System.IO.File.ReadAllText($@"..\..\doolhof{level}.txt");
            char[] textArray = text.ToCharArray();
            for (int i = 0; i < textArray.Length; i++)
            {
                Link newLink = new Link();
                newLink.Value = AssignValue(textArray[i]);

                if (textArray[i] == '@')
                {
                    truck = new Truck("@", newLink);
                    newLink.OccupiedBy = truck;

                }
                else if (textArray[i] == 'o')
                {
                    Box temp = new Box("o", newLink);
                    newLink.OccupiedBy = temp;
                    boxList.Add(temp);

                }
                else if (textArray[i] == '$')
                {
                    employee = new Employee("$", newLink);
                    newLink.OccupiedBy = employee;
                }

                if (BoardList.First == null)
                {
                    BoardList.First = newLink;
                    BoardList.Last = newLink;
                }
                else if (textArray[i] == '\n' || textArray[i] == '\r')
                {

                }
                else if (textArray[i - 1] == '\n')
                {
                    Link temp = BoardList.First;
                    while (temp.South != null)
                    {
                        temp = temp.South;
                    }
                    temp.South = newLink;
                    newLink.North = temp;
                    BoardList.Last = newLink;
                }
                else
                {
                    BoardList.Last.East = newLink;
                    newLink.West = BoardList.Last;
                    BoardList.Last = newLink;
                    try
                    {
                        newLink.North = newLink.West.North.East;
                        newLink.North.South = newLink;
                    }
                    catch (Exception)
                    {
                        newLink.North = null;
                    }
                }
            }
        }

        public GameObject AssignValue(char i)
        {
            if (i == '#')
            {
                return new Wall("█");
            }
            else if (i == '.' || i == 'o' || i == '$' || i == '@')
            {
                return new EmptyField(".");
            }
            else if (i == 'x')
            {
                return new DestinationField("x");
            }
            else if(i == '~')
            {
                return new TrapField("~");
            }
            
            return null;
        }
    }
}
