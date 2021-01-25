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

        /// <summary>
        /// this solution makes use of algorith called : "Sieve of Eratosthenes"
        /// https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
        /// ODSIEWANIE WIELOKROTONOSCI LICZB PRZY KOLEJNYCH WIELOKROTNOSCIACH NIE MA KOLEJNYCH SPRAWDZEN
        /// NP DLA 2 NIE MA SPRAWDZENB DLA 4 6 8 ITD
        /// first we create bool array of size n set all to true assuming they all prime
        /// then we filter out the not primes so all left at the end are primes
        /// doing this by filter out all multiplications of i from 2
        /// </summary>

        public static int CountPrimes2(int n)
        {
            if (n <= 2)
            {
                return 0;
            }

            var primes = new bool[n];
            for (int i = 0; i < n; i++)
            {
                primes[i] = true;
            }
            // so for n 100 we need to check multiplication of numbers 2-9
            // for 2 we set to false : 4, 6, 8 , 10, 12, ... 98
            // for 3 we set to false : 9, 12, 15 , 18, 21, ... 99
            // we dont check 100 cause indexes are until 99

            for(int i = 2; i * i < primes.Length; i++)
            {
                // i * i because there is no point to check over the squred number it doesn't exist
                if (primes[i])
                {
                    for (int j = i; j * i < primes.Length; j++)
                    {
                        // setting multiplications to false
                        primes[i * j] = false;
                    }
                }
            }

            // count the remaining true values as the ur primes
            int primesCount = 0;
            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    primesCount++;
                }
            }

            return primesCount;
        }

        // variation of the "Sieve of Eratosthenes"

        public static int CountPrimes3(int n)
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
