using System;

namespace PrimePalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxPrime = 999;
            int maxDiv = (int)Math.Sqrt(maxPrime);
            bool foundPrime = false;
            for (int i = maxPrime; i > 3; i -= 2)
            {
                foundPrime = true;
                for (int j = 3; j < maxDiv; j +=2 )
                {
                    if (i % j == 0 && i != j)
                    {
                        foundPrime = false;
                    } 
                }
                if(foundPrime)
                {
                    if (isPalindrom(i))
                    {
                        Console.WriteLine(i);
                        break;
                    }
                }
            }
            
            Console.ReadLine();
        }

        static bool isPalindrom(int p)
        {
            string test = p.ToString();
            string test2 = "";
            for(int i = test.Length -1; i >= 0; i--)
            {
                test2 += test[i];
            }

            return (test == test2);
        }
    }
}
