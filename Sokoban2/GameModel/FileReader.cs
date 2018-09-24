using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban2
{
    class FileReader
    {
        public Dictionary<Point, GameObject> GetGameObjectDictionary(String filePath)
        {
                  
            Dictionary<Point, GameObject> dictionary = new Dictionary<Point, GameObject>();
            string text = System.IO.File.ReadAllText(@filePath);
            
            int x = 0;
            int y = 0;
            foreach (var symbol in text)
            {

                if (symbol == '\n')
                {
                    y++;
                    x = 0;
                }
                else if (symbol != '\r')
                {
                    if (symbol == '#')
                    {
                        dictionary.Add(new Point(x,y), new Wall("Wall"));
                    }
                    else if (symbol == '.' || symbol == 'o' || symbol == '@')
                    {
                        dictionary.Add(new Point(x, y), new EmptyField("EmptyField"));
                    }
                    else if (symbol == 'x')
                    {
                        dictionary.Add(new Point(x, y), new DestinationField("DestinationField"));
                    }
                    x++;
                }
            }
            return dictionary;
        }

        public Dictionary<Point, GameObject> GetGamePiecesDictionary(String filePath)
        {
            Dictionary<Point, GameObject> dictionary = new Dictionary<Point, GameObject>();
            string text = System.IO.File.ReadAllText(@filePath);

            int x = 0;
            int y = 0;
            foreach (var symbol in text)
            {
                if (symbol == '\n')
                {
                    y++;
                    x = 0;
                }
                else if (symbol != '\r')
                {
                    if (symbol == 'o')
                    {
                        dictionary.Add(new Point(x, y), new Box("Box"));
                    }
                    else if (symbol == '@')
                    {
                        dictionary.Add(new Point(x, y), new Truck("Truck"));
                    }
                    x++;
                }
            }
            
            return dictionary;
        }

        public Dictionary<Point, GameObject> LoadObjectDictionary(int level)
        {
            return GetGameObjectDictionary($@"..\..\doolhof{level}.txt");
        }

        public Dictionary<Point, GameObject> LoadPiecesDictionary(int level)
        {
            return GetGamePiecesDictionary($@"..\..\doolhof{level}.txt");
        }


         
        public void PrintDictionary(int level) {
            foreach (var item in LoadObjectDictionary(level))
            {
                Console.WriteLine($"{ item.Key.X}, {item.Key.Y} = { item.Value.name}");
            }
            Console.WriteLine("===========================================");
            foreach (var item in LoadPiecesDictionary(level))
            {
                Console.WriteLine($"{ item.Key.X},{item.Key.Y} = { item.Value.name}");
            }
        }
        

    }
}
