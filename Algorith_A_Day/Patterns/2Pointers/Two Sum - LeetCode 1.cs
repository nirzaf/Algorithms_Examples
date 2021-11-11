using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns._2Pointers
{
    public class Two_Sum___LeetCode_1
    {

        //it works only for sorted arr which cannot be the case here
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
        //Input: nums = [2,7,11,15], target = 9
        // TryAdd - nice XDDD
        public static int[] TwoSums2(int target, int[] nums)
        {
            var visitedNums = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int delta = target - nums[i];
                if(visitedNums.ContainsKey(delta))
                {
                    return new[] { visitedNums[delta], i };
                }
                visitedNums.TryAdd(nums[i], i);
            }

            return new int[] { -1, -1 };
        }


    }
}
