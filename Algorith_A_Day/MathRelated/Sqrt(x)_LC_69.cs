using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.MathRelated
{
    public class Sqrt_x__LC_69
    {
        //timelimit exceeded for some reason
        public static int MySqrt(int x)
        {
            double result = 0;

            double upperBound = x;
            double lowerBound = 0.0;

            while(lowerBound < upperBound)
            {
                var mid = lowerBound + (upperBound - lowerBound) / 2;
                var current = Math.Pow(mid, 2);
                if (current == mid)
                {
                    result = mid;
                    return (int) current;
                }

                if (current < x)
                {
                    lowerBound = mid;
                }
                if (current > x)
                {
                    upperBound = mid;
                }
            }
            return (int)result;
        }

        public static int MySqrt2(int x)
        {
            if (x == 0) return 0;

            long left = 0;
            long right = int.MaxValue / 2 + 1;

            while (left < right)
            {
                long mid = left + (right - left) / 2;
                long candidate = mid * mid;
                if (candidate == mid)
                {
                    return (int)candidate;
                }
                else if (candidate > x)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return (int)left - 1;
        }
    }
}
