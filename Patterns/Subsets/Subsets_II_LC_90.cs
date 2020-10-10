using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Algorithm_A_Day.Patterns.Subsets
{
    public class Subsets_II_LC_90
    {
        /// <summary>
        /// Diffrence between this and withoug duplicate is:
        /// here we check nums for duplicate and get the start index accordingly but 
        /// nums MUST BE SORTED other wise same numbers won't be next to each other
        /// for [1,2,2] first we add empty [] to the list of lists
        /// first itteration:  1 != 0 so startIndex = 0  [] [1] 
        /// second itteration: 2 != 1 so startIndex = 0 [] [1] + [2] [1,2]    
        /// third itteration: 2 == 2 so startIndex = previosuSize -> 2, so we add 2 from index 2  [] [1] [2] [1,2]  + [2,2] [1,2,2]  
        /// </summary>

        // itaratively
        public static IList<IList<int>> SubsetsWithDup2(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            result.Add(new List<int>());

            Array.Sort(nums);
            int previousListSize = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int count = result.Count;
                // duplicate - skip already processed elements
                int startIndex = (i > 0 && nums[i] == nums[i - 1]) ? previousListSize : 0;
                previousListSize = count;

                for (int j = startIndex; j < count; j++)
                {
                    List<int> subset = result[j].ToList();
                    subset.Add(nums[i]);
                    result.Add(subset);
                }
            }

            return result;
        }
        public static IList<IList<int>> SubsetsWithDup3(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> result = new List<IList<int>>();
            List<int> currentList = new List<int>();
            helper(nums, result, currentList, 0);
            return result;
        }

        private static void helper(int[] nums, IList<IList<int>> result, List<int> currentList, int start)
        {
            result.Add(currentList.ToList());
            for (int i = start; i < nums.Length; i++)
            {
                if (i == start || nums[i] != nums[i - 1])
                {
                    currentList.Add(nums[i]);
                    helper(nums, result, currentList, i + 1);
                    currentList.RemoveAt(currentList.Count - 1);
                }
            }

        }



        //  it returns with result = [[],[1], [1,2], [1,2,2]] --> removal in currentList = [1, 2] ends
        //  4.helper(nums, [[],[1], [1,2]], [1,2,2], 3) calls and ends start > nums.len
        //  3.helper(nums, [[],[1]], [1,2], 2)
        //  2.helper(nums, [[]], [1], 1)
        //  1.helper(nums, [], [], 0)
    }
}
