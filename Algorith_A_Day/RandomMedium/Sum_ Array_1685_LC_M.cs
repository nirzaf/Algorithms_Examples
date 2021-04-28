using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomMedium
{
    public class Sum__Array_1685_LC_M
    {

        /// <summary>
        /// Brute force - time limit exceeded 
        /// </summary>
        public static int[] GetSumAbsoluteDifferences(int[] nums)
        {
            int[] result = new int[nums.Length];
            if (nums == null || nums.Length == 0) return result;

            for (int i = 0; i < nums.Length; i++)
            {
                int temp = 0;

                for (int j = 0; j < nums.Length; j++)
                {
                    temp += (Math.Max(nums[i], nums[j]) - Math.Min(nums[i], nums[j]));
                }
                result[i] = temp;
            }

            return result;
        }

        public static int[] GetSumAbsoluteDifferences2(int[] nums)
        {
            int[] prefixSum = new int[nums.Length + 1];

            for (int i = 0; i < nums.Length; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + nums[i];
            }

            int[] result = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                int right = (prefixSum[nums.Length] - prefixSum[i + 1]) - nums[i] * (nums.Length - i - 1);
                int left = 0;

                if (i > 0)
                {
                    left = nums[i] * i - prefixSum[i];
                }

                result[i] = left + right;
            }

            return result;
        }
    }
}
