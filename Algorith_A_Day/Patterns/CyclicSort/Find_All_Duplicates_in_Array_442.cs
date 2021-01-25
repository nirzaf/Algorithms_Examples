using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.Patterns.CyclicSort
{
    public class Find_All_Duplicates_in_Array_442
    {
        //{4,0,3,1}
        public static IList<int> FindDuplicates(int[] nums)
        {
            var result = new HashSet<int>();
            for (int i = 1; i < nums.Length + 1; i++)
            {
                int current = nums[i - 1];
                if (current != i)
                {
                    if (nums[current - 1] == current)
                    {
                        result.Add(current);
                        continue;
                    }
                    int temp = nums[current - 1];
                    nums[current - 1] = current;
                    nums[i - 1] = temp;
                    i--;
                }
            }
            return result.ToList();

            //var result = new List<int>();

            //var n = nums.Length;
            //for (int i = 0; i < n; i++)
            //{
            //    while (i != nums[i] - 1 && nums[nums[i] - 1] != nums[i])
            //    {
            //        var num = nums[i];
            //        nums[i] = nums[num - 1];
            //        nums[num - 1] = num;
            //    }
            //}

            //for (int i = 0; i < n; i++)
            //{
            //    if (nums[i] - 1 != i)
            //    {
            //        result.Add(nums[i]);
            //    }
            //}

            //return result;
        }
        //no sure why it doesnt count as extra space
        public static IList<int> FindDuplicates2(int[] nums)
        {
            var set = new HashSet<int>();
            var result = new List<int>();

            foreach (var num in nums)
            {
                if (set.Contains(num))
                    result.Add(num);

                set.Add(num);
            }

            return result;
        }
        /// <summary>
        /// here we make negative every element visited and then
        /// if it visited again add it to the result
        /// </summary>

        public static IList<int> FindDuplicates3(int[] nums)
        {
            IList<int> ret = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                //for negative already visited el
                int idx = Math.Abs(nums[i]) - 1;
                if (nums[idx] < 0)
                    ret.Add(Math.Abs(nums[i]));
                else
                    nums[idx] = -nums[idx];
            }
            return ret;
        }

    }
}


