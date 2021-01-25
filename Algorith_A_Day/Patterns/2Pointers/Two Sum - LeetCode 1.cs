using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns._2Pointers
{
    public class Two_Sum___LeetCode_1
    {
        public static int[] TwoSums(int target, int[] arr)
        {
            int[] result = new int[2];
            int s = 0;
            int e = arr.Length - 1;

            

            while(s < e)
            {
                int currentSum = arr[s] + arr[e];


                if (currentSum == target){
                    result[0] = s;
                    result[1] = e;
                    return result;
                }
                else if(currentSum < target)
                {
                    s++;
                }
                else
                {
                    e--;
                }
            }
            return new int[] { -1, -1 };
        }
    }
}
