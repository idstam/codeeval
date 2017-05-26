using System;
using System.Collections.Generic;
using System.IO;
using FacebookChallenge;

namespace FacebookChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var r = new StreamReader(args[0]))
            {
                string line;
                string validLetters = "abcdefghijklmnopqrstuvwxyz";
                line = r.ReadLine();
                do
                {

                    var letters = new Dictionary<char, int>();

                    foreach (var c in line.ToLower())
                    {
                        if (validLetters.Contains(c.ToString()))
                        {
                            if (letters.ContainsKey(c))
                            {
                                letters[c]++;
                            }
                            else
                            {
                                letters.Add(c, 1);
                            }
                        }
                    }
                    int letterPoint = 26;
                    int sum = 0;
                    var counts = new List<int>();
                    foreach (var count in letters.Values)
                    {
                        counts.Add(count);
                    }
                    counts.Sort();
                    counts.Reverse();
                    foreach (var count in counts)
                    {
                        sum += (count * letterPoint);
                        letterPoint--;
                    }
                    Console.WriteLine(sum);

                    line = r.ReadLine();
                } while (line != null);
            }

        }
    }
}
