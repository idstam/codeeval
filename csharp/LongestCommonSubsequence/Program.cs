using System;
using System.Collections.Generic;
using System.IO;

namespace LongestSequence
{
    static class Program
    {
        static void Main(string[] args)
        {
            using (var r = new StreamReader(args[0]))
            {
                //Console.WriteLine(DateTime.Now.ToLongTimeString());
                string line;
                line = r.ReadLine();
                do
                {
                    if (line.Trim() == "") continue;

                    var data = line.Split(new char[] { ';' });
                    string[] sequences = new string[data[0].Length];

                    string mData = data[0];
                    string tData = data[1];
                    int maxLen = 0;

                    char[] ms = new char[50];
                    string maxSequence = "";

                    long m_permCount = (long)Math.Pow( 2 , mData.Length);
                    for (long m = 0; m <= m_permCount ; m++)
                    {
                        int numOfOnes = 0;
                        int lastPos = 0;
                        int pos = 0;
                        for (int i = 0; i < mData.Length; i++)
                        {
                            if ((m & (1 << i)) != 0)
                            {
                                ms[numOfOnes] = mData[i];

                                pos = tData.IndexOf(ms[numOfOnes], lastPos);
                                if (pos == -1) break;
                                lastPos = pos + 1;
                                
                                numOfOnes++;
                            }
                        }

                        if (numOfOnes <= maxLen) continue;

                        if(pos != -1)
                        {
                            maxSequence = new string(ms, 0, numOfOnes);
                            maxLen = numOfOnes;
                        }
                    }


                    Console.WriteLine(maxSequence);
                    //Console.WriteLine(DateTime.Now.ToLongTimeString());

                    line = r.ReadLine();
                }
                while (line != null);

            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }        
    }
}