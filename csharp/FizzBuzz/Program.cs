using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var line in File.ReadAllLines(args[0]))
            {
                var numbers = line.Split(new char[] { ' ' });
                int m1 = int.Parse(numbers[0]);
                int m2 = int.Parse(numbers[1]);
                int end = int.Parse(numbers[2]);
                
                for(int i = 1; i <= end; i++)
                {
                    if (i % m1 != 0 && i % m2 != 0) Console.Write(i);
                    if (i % m1 == 0) Console.Write("F");
                    if (i % m2 == 0) Console.Write("B");
                    if (i < end) Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
