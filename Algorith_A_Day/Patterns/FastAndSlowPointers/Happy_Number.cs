using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.FastAndSlowPointers
{
    public class Happy_Number
    {
        public static bool IsHappy(int n)
        {
            int slow = n, fast = n;
            // we can use while like this beacuse 
            // if threre is a loop at some point it is 100 % that 
            // they will be equal and while break 
            // we just need to check if it's 1
            while (true)
            {
                slow = FindNext(slow);
                fast = FindNext(fast);
                fast = FindNext(fast);
                if (slow == fast) break;
            }
            return slow == 1;
        }

        private static int FindNext(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += (n % 10) * (n % 10);
                n /= 10;
            }

            return sum;
        }

        // ==== NO FAST AND SLOW POINTER SOLUTIONS
        public static bool IsHappy2(int n)
        {

            var nStr = n.ToString();
            
            var hashSet = new HashSet<int>();

            while (int.Parse(nStr) != 1)
            {
                if (hashSet.Contains(int.Parse(nStr))) return false;
                hashSet.Add(int.Parse(nStr));
                int currentSum = 0;
                for (int i = 0; i < nStr.Length; i++)
                {
                    var cur = int.Parse(nStr[i].ToString()) *
                              int.Parse(nStr[i].ToString());
                    currentSum += cur;
                }
                if (currentSum == 1)
                {
                    return true;
                }

                nStr = currentSum.ToString();
            }

            return true;
        }

        public static bool IsHappy3(int n)
        {
            HashSet<int> seen = new HashSet<int>();
            while (n != 1)
            {
                if (seen.Contains(n))
                    return false;
                seen.Add(n);
                int newNum = 0;
                while (n > 0)
                {
                    newNum += (int)Math.Pow(n % 10, 2);
                    n /= 10;
                }
                n = newNum;
            }
            return true;
        }
    }
}
