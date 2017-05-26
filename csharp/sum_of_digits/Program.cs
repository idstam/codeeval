using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using (StreamReader reader = File.OpenText(args[0]))
        {
            while (!reader.EndOfStream)
            {
                var foo = reader.ReadLine();
                var i = foo.ToCharArray().Sum(c => int.Parse(c.ToString()));
                Console.WriteLine(i);
            }
        }
    }
}