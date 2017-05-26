using System;

namespace PrimePalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            long curTest = 1;
            int primeCount = 1;
            long sum = 2;
            while (primeCount < 1000)
            {
                curTest+=2;
                if (isPrime(curTest))
                {
                    sum += curTest;
                    primeCount++;
                }
            }
            Console.WriteLine(sum);
        }

        //This will only work for odd numbers larger than one.
        static bool isPrime(long p)
        {
            long maxDiv = (long)Math.Sqrt(p) ;

            for (long j = 3; j <= maxDiv; j += 2)
            {
                if (p % j == 0 && p != j)
                {
                    return false;
                }
            }
            return true;
        }
    }
}