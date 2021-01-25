using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.Patterns.CyclicSort
{
    public class Set_Mismatch_LC_645
    {
        public static int[] FindErrorNums(int[] nums)
        {
            //{ 3,2,3}
            //{ 3,2,3}
            var set = new HashSet<int>();
            var result = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
                var current = nums[i];

                if (set.Add(current))
                {
                    continue;
                }
                else
                {
                    result[0] = current;
                }
            }

            var numsSet = new HashSet<int>(nums);
            int j = 1;
            while(j <= nums.Length + 1)
            {
                if (!numsSet.Contains(j))
                {
                    result[1] = j;
                    return result;
                }
                j++;
            }


            return result;
        }
        /// <summary>
        /// To find duplicate without hashmap we can use aux array 
        /// first populate whole array with 1 and and if any is already 1 it's duplicate
        /// then just find the index of 0 which is missed one
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] FindErrorNums2(int[] nums)
        {
            var temp = new int[nums.Length];
            int repeated = 0;
            int missed = 0;

            // find the repeated
            foreach (int num in nums)
            {
                if(temp[num -1] == 1)
                {
                    repeated = num;
                    continue;
                }
                temp[num - 1] = 1;
            }

            // find the missed one
            for (int i = 0; i < temp.Length; i++)
            {
                if(temp[i] == 0)
                {
                    missed = i + 1;
                }
            }

            return new int[] { repeated, missed };
        }

        public static int[] FindErrorNums3(int[] nums)
        {
            int len = nums.Length;
            HashSet<int> hset = new HashSet<int>(len);
            for (int i = 1; i <= len; i++)
                hset.Add(i);

            int[] result = new int[2];
            foreach (int n in nums)
                if (!hset.Remove(n))
                    result[0] = n;
            result[1] = hset.First();

            return result;
        }
    }
}
