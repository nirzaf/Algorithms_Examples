using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.Patterns.DP_01Knapsack
{
    public class Partition_Equal_Subset_Sum_LC_416
    {
        // DP tabulation
        public static bool CanPartition(int[] nums)
        {
            int maxSum = nums.Sum();
            //cannot be odd cause it is not possible to creat 2 equal subsets
            if (maxSum % 2 != 0) { return false; }

            int sum = maxSum / 2;
            bool[,] dp = new bool[sum + 1, nums.Length + 1];

            dp[0, 0] = true;

            for (int i = 0; i <= sum; i++)
            {
                for (int j = 1; j <= nums.Length; j++)
                {
                    if (i - nums[j - 1] < 0)
                    {
                        dp[i, j] = dp[i, j - 1];
                    }
                    else
                    {
                        dp[i, j] = dp[i, j - 1] || dp[i - nums[j - 1], j - 1];
                    }
                }
            }

            return dp[sum, nums.Length];
        }
        //recursion & memoization DP
        public static bool CanPartitionRecur(int[] nums)
        {
            int maxSum = nums.Sum();
            if (maxSum % 2 != 0) { return false; }

            return CanPartitionRecur(nums, 0, 0, maxSum, new Dictionary<string, bool>() ); 
        }
        //without DP
        //private static bool CanPartitionRecur(int[] nums, int index, int sum, int maxSum)
        //{
        //    //we looking for sum *2 == maxSum
        //    if (sum * 2 == maxSum)
        //        return true;
        //    //if we collect too big of a sum or walk through all the numbers in arr
        //    if (sum > maxSum / 2 || index >= nums.Length)
        //        return false;

        //    return CanPartitionRecur(nums, index + 1, sum, maxSum)
        //        || CanPartitionRecur(nums, index + 1, sum + nums[index], maxSum);
        //}
        //with DP
        private static bool CanPartitionRecur(int[] nums, int index, int sum, int maxSum, Dictionary<string, bool> state)
        {
            string currentState = index + "" + sum;
            if (state.ContainsKey(currentState))
            {
                return state[currentState];
            }
            //we looking for sum *2 == maxSum
            if (sum * 2 == maxSum)
                return true;
            //if we collect too big of a sum or walk through all the numbers in arr
            if (sum > maxSum / 2 || index >= nums.Length)
                return false;

            bool foundPartition = CanPartitionRecur(nums, index + 1, sum, maxSum, state)
                || CanPartitionRecur(nums, index + 1, sum + nums[index], maxSum, state);
            state.Add(currentState, foundPartition);

            return foundPartition;
        }
    }
}
