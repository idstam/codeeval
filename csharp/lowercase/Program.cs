using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                var foo = reader.ReadLine();
                if (foo != null) Console.WriteLine(foo.ToLowerInvariant());
            }

    }
}