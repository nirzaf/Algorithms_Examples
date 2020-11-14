using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Arrays
{
    public class Shuffle_the_Array_LC_1470_E
    {
        public static int[] Shuffle(int[] nums, int n)
        {
            var result = new List<int>();
            if (nums.Length % 2 != 0) return result.ToArray();
            int midLen = n;

            for (int i = 0; i < midLen; i++)
            {
                result.Add(nums[i]);
                result.Add(nums[n]);
                n++;
            }

            return result.ToArray();
        }

        // with array [2 * i]
        // TC = O(n)
        public static int[] Shuffle2(int[] nums, int n)
        {

            if (nums == null || nums.Length == 0)
                return nums;

            int[] res = new int[2 * n];

            for (int i = 0; i < n; i++)
            {
                res[2 * i] = nums[i];
                res[2 * i + 1] = nums[n + i];
            }

            return res;
        }

        //2 pointers
        // every iteration it set new int in result 
        // isFirst is a helper to decide on index
        public int[] Shuffle3(int[] nums, int n)
        {
            int[] result = new int[nums.Length];
            int index = 0;
            bool isFirst = true;
            int i = 0, j = n;

            while (i < n || j < nums.Length)
            {
                if (isFirst)
                {
                    result[index++] = nums[i++];
                }
                else
                {
                    result[index++] = nums[j++];
                }

                isFirst = !isFirst;
            }

            return result;
        }
    }
}
