using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Algorithm_A_Day.Patterns.Subsets
{
    public class Subsets_II_LC_90
    {
        public static IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            if (nums.Length == 0) return new List<IList<int>>();

            var result = new List<IList<int>>();
            result.Add(new List<int>());

            for (int i = 0; i < nums.Length; i++)
            {
                var size = result.Count;
                for (int j = 0; j < size; j++)
                {
                    var tempList = result[j].ToList();
                    tempList.Add(nums[i]);

                    if(!IsListInList(result, tempList))
                    result.Add(tempList);
                }
            }
            
            return result;
        }

        private static bool IsListInList(List<IList<int>> result, List<int> tempList)
        {
            bool result1 = false;
            foreach (var list in result)
            {
                if(list.Count == tempList.Count)
                {
                    bool isSame = false;
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if(list[i] == tempList[i])
                        {
                            isSame = true;
                        }
                        else
                        {
                            isSame = false;
                        }
                    }
                    if(isSame == true)
                    {
                        result1 = true;
                        break;
                    }
                }
            }
            return result1;
        }
        // itarative
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

        private void helper(int[] nums, IList<IList<int>> result, List<int> currentList, int start)
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
    }
