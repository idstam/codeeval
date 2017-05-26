// https://www.codeeval.com/open_challenges/168/


using System;
using System.IO;

namespace Test
{
    
    class Program
    {
        static void Main(string[] args)
        {
            string[] s;
            using (var r = new StreamReader(args[0]))
            {
                string line;
                line = r.ReadLine();
                do
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    Console.WriteLine(line);

                    line = r.ReadLine();
                }
                while (line != null);
            }
            Console.ReadLine();
        }
    }
}
