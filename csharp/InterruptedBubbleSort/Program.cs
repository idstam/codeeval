using System;
using System.IO;
using System.Text;

//https://www.codeeval.com/open_challenges/158/


namespace InterruptedBubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var r = new StreamReader(args[0]))
            {
                string line;
                line = r.ReadLine();

                do
                {
                    if (line.Trim() == "") continue;
                    
                    var strings = line.Split(new char[] { ' ' });
                    UInt64 iterations = UInt64.Parse(strings[strings.Length - 1]);
                    var ints = new UInt64[strings.Length - 2];
                    UInt64 swap;
                    for (int i = 0; i < ints.Length; i++)
                    {
                        ints[i] = UInt64.Parse(strings[i]);
                    }

                    for (UInt64 i = 0; i < iterations; i++)
                    {
                        bool didSwap = false;
                        for (int p = 0; p < ints.Length - 1; p++)
                        {
                            if (ints[p] > ints[p + 1])
                            {
                                didSwap = true;
                                swap = ints[p];
                                ints[p] = ints[p + 1];
                                ints[p + 1] = swap;
                            }
                        }
                        if (!didSwap) break;
                    }

                    StringBuilder s = new StringBuilder();
                    for (int p = 0; p < ints.Length; p++)
                    {
                        s.Append(ints[p].ToString());
                        if (p < (ints.Length - 1)) s.Append(" ");

                    }
                    Console.WriteLine(s.ToString());
                    line = r.ReadLine();
                }
                while (line != null);
            }

         //   Console.ReadLine();

        }

    }
}
