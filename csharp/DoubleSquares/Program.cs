using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {

        using (StreamReader reader = File.OpenText(args[0]))
        //using (StreamReader reader = File.OpenText(@"d:\temp\codeeval\data.txt"))
        {
            string line = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                if (null == line)
                    continue;
                long x = long.Parse(line);
                var count = Count(x);
                Console.WriteLine(count);
            }
        }
    }

    private static int Count(long x)
    {
        long i = 0;
        long d = 0;
        int count = 0;

        while (d <= x)
        {
            var y = x - d;
            if (y < d && isDouble(y))
            {
                count++;
            }
            i++;
            d = i * i;
        }
        return count;
    }

    private static bool isDouble(long d)
    {
        var s = (long) Math.Sqrt(d);
        return (d == s * s);
    }

}