using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.Sliding_Window
{
    public class Maximum_Sum_Subarray_of_Size_K
    {
        /// <summary>
        /// Goal Given an array of positive numbers and a positive number ‘k’,
        /// find the maximum sum of any contiguous subarray of size ‘k.
        /// Input: [2, 1, 5, 1, 3, 2], k=3 
        /// Output: 9
        /// Explanation: Subarray with maximum sum is [5, 1, 3].
        /// </summary>
        public static int findMaxSumSubArray(int k, int[] arr)
        {
            int result = 0;
            int currentSum = 0;
            int start = 0;

            for (int i = 0; i < arr.Length ; i++)
            {
                //firstly it's sum k elements than add one and compare
                currentSum += arr[i];

                //after k elements it compares sum and max current sum 
                // then subrust very left element
                if(i >= k - 1)
                {
                    result = Math.Max(result, currentSum); //if (currentSum > result) result = currentSum;
                    currentSum -= arr[start];
                    start++;
                }                
            }

            return result;
        }
    }
}
