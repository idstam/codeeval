using System;
using System.IO;
using System.Text;

namespace PassTriangle
{
    //https://www.codeeval.com/open_challenges/89/

    class Program
    {
        static void Main(string[] args)
        {
            UInt64[] lastLine = new UInt64[0];
            UInt64[] curLine = new UInt64[0];
            using (var r = new StreamReader(args[0]))
            {
                string line;
                line = r.ReadLine();

                //bootstrap the first line

                curLine = new UInt64[3] { 0, UInt64.Parse(line), 0 };
                line = r.ReadLine();
                do
                {
                    lastLine = curLine;
                    var strings = line.Trim().Split(new char[] { ' ' });
                    curLine = new UInt64[strings.Length + 2];
                    for (int i = 1; i <= strings.Length; i++)
                    {
                        UInt64 left = UInt64.Parse(strings[i - 1]) + lastLine[i - 1];
                        UInt64 right = UInt64.Parse(strings[i - 1]) + lastLine[i];
                        if(left > right)
                        {
                            curLine[i] = left;
                        }
                        else
                        {
                            curLine[i] = right;
                        }

                    }

                    line = r.ReadLine();
                }
                while (line != null);
            }
            UInt64 maxVal = 0;
            for(int i = 1; i < curLine.Length; i++)
            {
                if (curLine[i] > maxVal) maxVal = curLine[i];
            }
            Console.WriteLine(maxVal.ToString());
            //Console.ReadLine();

        }
    }
}
