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
                    bool overlapping = false;

                    var numbers = line.Split(new char[] { ',' });
                    var ints = new int[numbers.Length];
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        ints[i] = int.Parse(numbers[i]);
                    }


                    //Top left
                    if (ints[0].Between(ints[4], ints[6]) && ints[1].Between(ints[5], ints[7]))
                    {
                        overlapping = true;
                    }
                    //Topright
                    if (ints[2].Between(ints[4], ints[6]) && ints[1].Between( ints[5], ints[7]))
                    {
                        overlapping = true;
                    }

                    //Bottom left
                    if (ints[0].Between(ints[4], ints[6]) && ints[3].Between(ints[5], ints[7]))
                    {
                        overlapping = true;
                    }
                    //bottom right
                    if (ints[2].Between(ints[4], ints[6]) && ints[3].Between(ints[5], ints[7]))
                    {
                        overlapping = true;
                    }


                    //Top left
                    if (ints[4].Between(ints[0], ints[2]) && ints[5].Between(ints[1], ints[3]))
                    {
                        overlapping = true;
                    }
                    //Topright
                    if (ints[6].Between(ints[0], ints[2]) && ints[5].Between(ints[1], ints[3]))
                    {
                        overlapping = true;
                    }

                    //Bottom left
                    if (ints[4].Between(ints[0], ints[2]) && ints[7].Between(ints[1], ints[3]))
                    {
                        overlapping = true;
                    }
                    //bottom right
                    if (ints[6].Between(ints[0], ints[2]) && ints[7].Between(ints[1], ints[3]))
                    {
                        overlapping = true;
                    }


                    Console.WriteLine(overlapping);

                    line = r.ReadLine();
                } while (line != null);
            }


            Console.ReadLine();
        }
        static bool Between(this int x, int a, int b)
        {
            int f, l;
            if (a > b)
            {
                f = b;
                l = a;
            }
            else
            {
                f = a;
                l = b;
            }

            return (x >= f && x <= l);
        }
    }
}