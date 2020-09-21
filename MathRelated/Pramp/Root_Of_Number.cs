using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.MathRelated.Pramp
{
    /// <summary>
    /// https://www.youtube.com/watch?v=S2VfJh8J0gc&t=2788s
    /// </summary>
    public class Root_Of_Number
    {
        public static double Root(double x, int n)
        {
            if (x == 0) return 0;

            double lowerBound = 0;
            double upperBound = Math.Max(1, x);
            double error = 0.001;
            double approxRoot = (lowerBound + upperBound) / 2;

            while(approxRoot - lowerBound >= error)
            {
                if(Math.Pow(approxRoot, n) > x)
                {
                    upperBound = approxRoot;
                }
                else if(Math.Pow(approxRoot, n) < x)
                {
                    lowerBound = approxRoot;
                }
                else
                {
                    break;
                }

                approxRoot = (upperBound + lowerBound) / 2;
            }
            return approxRoot;

        }
         //9 / 2 = 4.5     4.5 * 4.5 20,25 > 9   3
    }
}
