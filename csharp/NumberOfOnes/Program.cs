using System;
using System.IO;

namespace OverlappingRectangles
{
    static class Program
    {
        static void Main(string[] args)
        {
            using (var r = new StreamReader(args[0]))
            {
                string line;
                line = r.ReadLine();
                do
                {
                    int i = int.Parse(line);
                    var b = Convert.ToString(i, 2);
                    i = 0;

                    foreach(char c in b)
                    {
                        if (c == '1') i++;
                    }
                    Console.WriteLine(i);
                    line = r.ReadLine();
                } 
                while (line != null);
            }

        }
    }
}