using System;
using System.IO;

namespace LongestLine
{
    class Program
    {
        static void Main(string[] args)
        {           
            int numToPrint = 0;
            string[] s;
            using (var r = new StreamReader(args[0]))
            {
                string line;
                line = r.ReadLine();
                numToPrint = int.Parse(line);
                s = new string[numToPrint];
                int shortest = 0;

                for (int i = 0; i < numToPrint; i++) s[i] = "";
                line = r.ReadLine();
                do
                {    
                    if(line.Length > shortest)
                    {
                        string bubble = line;
                        for (int i = 0; i < numToPrint; i++)
                        {
                            if( s[i].Length < bubble.Length)
                            {
                                string swap = s[i];
                                s[i] = bubble;
                                
                                if(shortest > bubble.Length) shortest = bubble.Length;

                                bubble = swap;
                            }
                        }
                    }
                    
                    line = r.ReadLine();
                }
                while (line != null);
            }
            foreach(var l in s)
            {
                Console.WriteLine(l);
            }
            //Console.ReadLine();
        }
    }
}
