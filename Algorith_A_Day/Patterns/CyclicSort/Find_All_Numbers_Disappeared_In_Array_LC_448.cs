using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.Patterns.CyclicSort
{
    public class Find_All_Numbers_Disappeared_In_Array_LC_448
    {
        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            if (nums.Length == 0) return new List<int>();

            var result = new List<int>();
            var len = nums.Length;
            Array.Sort(nums);

            var set = new HashSet<int>(nums);
            int index = 1;


            while(index <= len)
            {
                if (!set.Contains(index))
                {
                    result.Add(index);
                }
                index++;
            }

            return result;


            //var res = new HashSet<int>(Enumerable.Range(1, nums.Length));
            //foreach (var item in nums)
            //    res.Remove(item);
            //return res.ToArray()

        }
        /// <summary>
        /// Explanation: You create a hashset of numbers 1-n,
        /// and then remove numbers already at the original array.
        /// Using hashset instead of list makes runtime faster, as hashsets are the fastest dynamic collection.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<int> FindDisappearedNumbers2(int[] nums)
        {
            IList<int> res = new List<int>();

            //populate the array accordingly do valfrom nums and make values negative
            // in that way we know all the indexes + 1 with positive values are missing ones
            for (int i = 0; i < nums.Length; i++)
            {
                int val = Math.Abs(nums[i]);
                nums[val - 1] = -Math.Abs(nums[val - 1]);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    res.Add(i + 1);
                }
            }

            return res;
        }
        /// <summary>
        /// However, the description asked to use the least memory possible.
        /// To do so, we must use the original array only, both for processing and as result array.
        /// Code gets way uglier, tho. The trick here is iterate the array backwards,
        /// and swapping each number to its correct position, which is "nums[i+1]".
        /// Then we scan the array again, and check which number is not present (meaning it was a disappeared number).
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<int> FindDisappearedNumbers3(int[] nums)
        {
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                while (nums[i] != i + 1 && nums[nums[i] - 1] != nums[i])
                    (nums[i], nums[nums[i] - 1]) = (nums[nums[i] - 1], nums[i]);//tuple swap look i alogo practical file
            }
            int idx = 0;
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] != i + 1) nums[idx++] = i + 1;
            return nums[0..idx];
        }
    }
}
