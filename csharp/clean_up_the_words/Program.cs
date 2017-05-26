using System;
using System.IO;
using System.Text;

namespace clean_up_the_words
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    var foo = reader.ReadLine();
                    if (foo == null) continue;

                    var skip = false;
                    var result = new StringBuilder();
                    foreach (var c in foo)
                    {
                        if (Char.IsLetter(c))
                        {
                            skip = false;
                            result.Append(c);
                        }
                        else
                        {
                            if(skip) continue;

                            skip = true;
                            result.Append(" ");
                        }
                    }

                    Console.WriteLine(result.ToString().Trim().ToLowerInvariant());
                }
            }
        }
    }
}
