using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.Patterns.Subsets
{
    public class Subsets_LC_78
    {
        public static IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            result.Add(new List<int>());

            foreach (var num in nums)
            {
                //save the count now because result count keeps changing
                int currentCount = result.Count;
                for (int i = 0; i < currentCount; i++)
                {
                    var x = result[i];
                    List<int> subset = result[i].ToList();// save the current list
                    subset.Add(num);
                    result.Add(subset);
                }
            }

            return result;
        }
        public static IList<IList<int>> Subsets2(int[] nums)
        {
            var result = new List<IList<int>>();
            if (nums.Length == 0) return result;

            result.Add(new List<int>() { });

            for (int i = 0; i < nums.Length; i++)
            {
                List<IList<int>> newResult = new List<IList<int>>();
                foreach (var r in result)
                {
                    List<int> nr = new List<int>(r);
                    nr.Add(nums[i]);
                    newResult.Add(nr);
                }
                result.AddRange(newResult);
            }
            return result;
        }
        // RECURSIVELY
        public static IList<IList<int>> SubsetsRecur(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            List<int> currentList = new List<int>();
            helper(nums, result, currentList, 0);
            return result;
        }

        private static void helper(int[] nums, IList<IList<int>> result,
                                    List<int> currentList, int start)
        {
            result.Add(currentList.ToList());
            for (int i = start; i < nums.Length; i++)
            {
                currentList.Add(nums[i]);
                helper(nums, result, currentList, i + 1);
                currentList.RemoveAt(currentList.Count - 1);
            }
        }
    }
}
