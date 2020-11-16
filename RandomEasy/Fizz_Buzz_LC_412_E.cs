using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.RandomEasy
{
    public class Fizz_Buzz_LC_412_E
    {
        public IList<string> FizzBuzz(int n)
        {
            var result = new List<string>();
            if (n < 1) return result;

            for (int i = 1; i < n + 1; i++)
            {
                if (i % 5 == 0 && i % 3 == 0)
                {
                    result.Add("FizzBuzz");
                }
                else if (i % 5 == 0)
                {
                    result.Add("Buzz");
                }
                else if (i % 3 == 0)
                {
                    result.Add("Fizz");
                }
                else
                {
                    result.Add(i.ToString());
                }
            }
            return result;
        }


        //LINQ 
        public IList<string> FizzBuzz2(int n)
        {
            return Enumerable.Range(1, n).Select(x => (x % 5 + x % 3 == 0) ? "FizzBuzz" : (x % 3 == 0 ? "Fizz" : x % 5 == 0 ? "Buzz" : x.ToString())).ToList();
        }

        // with SB
        public IList<string> FizzBuzz3(int n)
        {
            string[] results = new string[n];

            for (int i = 1; i <= n; i++)
            {
                StringBuilder result = new StringBuilder();
                if (i % 3 == 0)
                {
                    result.Append("Fizz");
                }
                if (i % 5 == 0)
                {
                    result.Append("Buzz");
                }
                else if (i % 3 > 0)
                {
                    result.Append(i.ToString());
                }
                results[i - 1] = result.ToString();
            }

            return results;
        }

        // LIKE A BOSS 
        private const string FizzCached = "Fizz";
        private const string BuzzCached = "Buzz";
        private const string FizzBuzzCached = "FizzBuzz";

        private static string CalcFizzBuzz(int x) => (x % 3, x % 5) switch
        {
            (0, 0) => FizzBuzzCached,
            (0, _) => FizzCached,
            (_, 0) => BuzzCached,
            _ => x.ToString()
        };

        public IList<string> FizzBuzz4(int n) => Enumerable
            .Range(1, n)
            .Select(CalcFizzBuzz)
            .ToList();
    }
}
