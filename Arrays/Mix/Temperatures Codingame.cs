using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.Arrays.Mix
{
    /// <summary>
    /// Goal: Get the closest element to 0;
    /// https://www.codingame.com/ide/puzzle/temperatures
    /// </summary>
    public class Temperatures_Codingame
    {
        public static int GetTheClosest(int[] arr)
        {
            int tempP = 5526;   //max positive value depends on constrains
            int tempN = -5526;  //min negative value


            for (int i = 0; i < arr.Length; i++)
            {
                int t = arr[i];// a temperature expressed as an integer ranging from -273 to 5526

                //t is bigger than 0 and current tempP is bigger than t
                if (0 < t && tempP > t)
                {
                    tempP = t;
                }
                //t is negative and current tempN is smaller than t  , -1 > -3    XD
                else if (0 > t && tempN < t)
                {
                    tempN = t;

                }
            }
            //empty arr
            if (arr.Length == 0)
            {
                tempP = 0;
            }//we can compere them making the tempN positive 
            if (tempN * (-1) < tempP)
            {
                tempP = tempN;
            }
            return tempP;
        }

        public static void BruteForce(int[] arr)
        {
            var negatives = new List<int>();
            var positives = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int t = arr[i];
                if (t >= 0) positives.Add(t);
                else
                {
                    negatives.Add(t);
                }
            }

            int maxPositive = positives.Count() != 0 ? positives.Min() : -1;
            int maxNegative = negatives.Count() != 0 ? Math.Abs(negatives.Max()) : -1;

            //empty arr
            if (positives.Count() == 0 && negatives.Count() == 0)
            {
                Console.WriteLine(0);

            }
            else
            {
                //no positive numbers
                if (maxPositive == -1)
                {
                    Console.WriteLine(maxNegative * -1);
                }
                //no negative numbers
                else if (maxNegative == -1)
                {
                    Console.WriteLine(maxPositive);
                }
                //both neg and pos present
                else
                {
                    if (maxPositive < maxNegative)
                    {
                        Console.WriteLine(maxPositive);
                    }
                    else Console.WriteLine(maxNegative);
                }
            }
        }

        public static int LinqSolution(int[] arr)
        {
            return arr.Select(x => x)
            .OrderBy(Math.Abs)
            .ThenByDescending(x => x)
            .FirstOrDefault();
        }
    }
}
