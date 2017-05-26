using System;
using System.IO;

namespace DataRecovery
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var r = new StreamReader(args[0]))
            {
                string line;
                line = r.ReadLine();
                do
                {
                    
                    var data = line.Split(new char[] { ';' });
                    var words = data[0].Split(new char[] { ' ' });
                    var numbers = data[1].Split(new char[] { ' ' });
                    var result = new string[words.Length];

                    int numSum = 0;
                    int totSum = 0;
                    for (int i = 0; i < numbers.Length; i++ )
                    {
                        totSum += (i+1);
                        int num = int.Parse(numbers[i]);
                        numSum += num;
                        result[num-1] = words[i];
                    }
                    totSum += words.Length;
                    result[(totSum - numSum) -1] = words[words.Length -1];

                    Console.WriteLine(string.Join(" ", result));
                    line = r.ReadLine();
                } while (line != null);
            }


            Console.ReadLine();
        }
    }
}
