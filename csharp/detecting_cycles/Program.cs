using System;
using System.IO;
using System.Collections.Generic;

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
                var list = foo.Split(new char[] {' '});
                var result = new List<string>();
                int h = 0;
                int r = 1;
                while (h < list.Length)
                {
                    while (r < list.Length)
                    {
                        if (list[h] == list[r])
                        {
                            if (result.Count > 0 && result[0] == list[h])
                            {
                                h = list.Length;
                                break;
                            }
                            result.Add(list[h]);
                            h++;
                            if (h == r) break;
                        }
                        r++;
                    }
                    
                    h++;
                    r = h + 1;

                }

                Console.WriteLine(string.Join(" ", result));
            }
        }

        //Console.ReadLine();
    }
}

/*

6 3 1
49
1 2 3

*/
