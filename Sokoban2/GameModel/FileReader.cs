using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban2
{
    class FileReader
    {
        public Dictionary<string,GameObject> ReadFile(String filePath)
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
                    else if (symbol == '.')
                    {
                        dictionary.Add($"{x},{y}", new EmptyField("EmptyField"));
                    }
                    else if (symbol == 'x')
                    {
                        dictionary.Add($"{x},{y}", new DestinationField("DestinationField"));
                    }
                    else if (symbol == 'o')
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

        public void PrintDictionary() {
            //testmethode
            foreach (var item in ReadFile(@"C:\Users\alexa\Desktop\sokoban\Doolhof\doolhof1.txt"))
            {
                Console.WriteLine($"{ item.Key} = { item.Value}");
            }
        }



    }
}
