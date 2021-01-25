using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.RandomEasy
{
    public class Number_of_Good_Pairs_1512_LC_E
    {
        public int NumIdenticalPairs(int[] nums)
        {
            if (nums.Length < 2) return 0;

            int good_pairs = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j] && i < j) good_pairs++;
                }
            }
            return good_pairs;
        }
    }
}
