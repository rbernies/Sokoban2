﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban2
{
    class FileReader
    {
        public Dictionary<string, GameObject> GetGameObjectDictionary(String filePath)
        {
            Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();
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
                        dictionary.Add($"{x},{y}", new Wall("Wall"));
                    }
                    else if (symbol == '.' || symbol == 'o' || symbol == '@')
                    {
                        dictionary.Add($"{x},{y}", new EmptyField("EmptyField"));
                    }
                    else if (symbol == 'x')
                    {
                        dictionary.Add($"{x},{y}", new DestinationField("DestinationField"));
                    }
                    x++;
                }
            }
            return dictionary;
        }

        public Dictionary<string, GameObject> GetGamePiecesDictionary(String filePath)
        {
            Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();
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
                        dictionary.Add($"{x},{y}", new Box("Box"));
                    }
                    else if (symbol == '@')
                    {
                        dictionary.Add($"{x},{y}", new Truck("Truck"));
                    }
                    x++;
                }
            }
            return dictionary;
        }

        public Dictionary<string, GameObject> LoadObjectDictionary(int level) {
          return GetGameObjectDictionary($@"C:\Users\alexa\Desktop\sokoban\Doolhof\doolhof{level}.txt");
        }

        public Dictionary<string, GameObject> LoadPiecesDictionary(int level)
        {
            return GetGamePiecesDictionary($@"C:\Users\alexa\Desktop\sokoban\Doolhof\doolhof{level}.txt");
        }


        /* For testing purposes
         
        public void PrintDictionary() {
            foreach (var item in GetGameObjectDictionary(@"C:\Users\alexa\Desktop\sokoban\Doolhof\doolhof1.txt"))
            {
                Console.WriteLine($"{ item.Key} = { item.Value.name}");
            }
            Console.WriteLine("===========================================");
            foreach (var item in GetGamePiecesDictionary(@"C:\Users\alexa\Desktop\sokoban\Doolhof\doolhof1.txt"))
            {
                Console.WriteLine($"{ item.Key} = { item.Value.name}");
            }
        }
        */


    }
}
