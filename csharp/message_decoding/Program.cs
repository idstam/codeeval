using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace message_decoding
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            {
                var codeKeys = CodeKeys();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    int mstart = MessageStart(line);
                    var header = line.Substring(0, mstart);
                    var codedMessage = line.Substring(mstart, (line.Length - mstart));
                    var curPos = 0;
                    var decodedMessage = new StringBuilder();
                    
                    while (curPos < codedMessage.Length)
                    {
                        var foo = codedMessage.Substring(curPos, 3);
                        var tokenLength = Convert.ToInt32(foo, 2);
                        if (tokenLength == 0)
                        {
                            break;
                        }
                        var ones = new string('1', tokenLength);
                        curPos += 3;

                        while (curPos < codedMessage.Length)
                        {
                            var curKey = codedMessage.Substring(curPos, tokenLength);
                            curPos += tokenLength;
                            if (curKey == ones)
                            {
                                break;
                            }
                            var curChar = header[codeKeys[curKey]];
                            decodedMessage.Append(curChar);
                            
                        }

                    }
                    Console.WriteLine(decodedMessage.ToString());
                }
            }

            //Console.ReadLine();
        }

        private static Dictionary<string, int>CodeKeys()
        {
            var ret = new Dictionary<string, int>();
            int count = 0;
            for(int i = 1; i < 8; i++)
            {
                var jmax = Math.Pow(2, i)-1;
               
                for (int j = 0; j < jmax; j++)
                {
                    var newKey = Convert.ToString(j, 2).PadLeft(i, '0') ;
                    //Console.WriteLine(newKey + " " + count);
                    ret.Add(newKey, count);
                    count++;
                }
            }
            return ret;
        }
        private static int MessageStart(string line)
        {
            var ret = 0;
            foreach (var c in line)
            {
                if (c == '1' || c == '0') return ret;

                ret++;
            }
            return ret;
        }

    }

}
