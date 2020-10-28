using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.MathRelated
{
    public class Count_Primes_LC_204
    {

        /// <summary>
        /// brute force 
        /// time limit exceeded
        /// </summary>

        public static int CountPrimes(int n)
        {
            if (n == 0 || n == 1) return 0;

            var result = new List<int>();

            for (int i = 2; i < n; i++)
            {
                if (CheckPrime(i, n))
                {
                    result.Add(i);
                }
            }

            return result.Count;
        }

        private static bool CheckPrime(int n, int len)
        {
            if (len > 100) len = len / 10;
            for (int i = 2; i < len; i++)
            {
                if (n % i == 0 && i != n)
                {
                    return false;
                }
            }
            return true;
        }

        public static int CountPrimes2(int n)
        {
            if (n <= 2)
            {
                return 0;
            }

            var nonPrimes = new bool[n];

            int count = 0;
            nonPrimes[2] = false;

            for (int number = 2; number < n; number++)
            {
                if (!nonPrimes[number])
                {
                    for (int i = 1; i * number < n; i++)
                    {
                        nonPrimes[i * number] = true;
                    }

                    count++;
                }
            }

            return count;
        }
    }
}
