using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Algorithms.Kadane_s
{
    class Maximum_Subarray_LC_53_E
    {
        public static int MaxSubArray(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 0 || nums == null) return 0;

            int sum = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                int tempSum = nums[i];
                sum = Math.Max(tempSum, sum);
                if (i + 1 < nums.Length - 1)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        tempSum += nums[j];
                        sum = Math.Max(tempSum, sum);
                    }
                }

            }
            return sum;
        }

        // Kadane's algo 
        /// <summary>
        /// we start with both sum variables set to first element
        /// then each iteration we check what is bigger:
        /// 1.current sum + next element or next element WHY?
        /// because it only makes sense to add next element if its not smaller
        /// e.g. -2+ 1 = -1 so it better to set currentSum to current element
        /// 2. currentSum or max sum and set max sum 
        /// 
        /// </summary>
        public static int MaxSubArray2(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 0 || nums == null) return 0;

            int size = nums.Length;
            int maxSum = nums[0];
            int currentSum = maxSum;

            for (int i = 1; i < size; i++)
            {
                currentSum = Math.Max(nums[i] + currentSum, nums[i]);
                maxSum = Math.Max(currentSum, maxSum);
            }

            return maxSum;
        }

        //Kadane's algo variation ?

        public static int MaxSubArray3(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 0 || nums == null) return 0;

            int size = nums.Length;
            int maxSoFar = int.MinValue;
            int maxEndingHere = 0;

            for (int i = 0; i < size; i++)
            {
                maxEndingHere += nums[i];
                if (maxSoFar < maxEndingHere)
                {
                    maxSoFar = maxEndingHere;
                }
                if (maxEndingHere < 0)
                {
                    maxEndingHere = 0;
                }
            }

            return maxSoFar;
        }
    }
}
