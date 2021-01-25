using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns._2Pointers
{
    /// <summary>
    /// first we need to sort the array so we can make use of pointers
    /// we do 2Sum for each number in array 
    /// to avoid duplicates we move pointers if the numbers in array are the same  
    /// </summary>
    public class _Sum_LC_15
    {
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();
            if (nums.Length == 0 || nums == null) return result;
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;
                int sum = 0 - nums[i];
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    while (left < right)
                    {
                        if (nums[left] + nums[right] == sum)
                        {
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });
                            while (left < right && nums[left] == nums[left + 1]) left++;
                            while (left < right && nums[right] == nums[right - 1]) right--;
                            left++;
                            right--;
                        }
                        else if (nums[left] + nums[right] > sum)
                        {
                            right--;
                        }
                        else
                        {
                            left++;
                        }
                    }
                }
            }
            return result;

        }
        
        // variation of above
        public static List<List<int>> FindTriplets(int[] arr)
        {
            var result = new List<List<int>>();
            var tempSumIndex = 0;
            while (tempSumIndex < arr.Length)
            {
                int leftIndex = 0;
                int rightIndex = arr.Length - 1;
                while (leftIndex < rightIndex)//arr is sorted
                {
                    if (arr[leftIndex] + arr[rightIndex] > arr[tempSumIndex])
                    {
                        rightIndex--;
                    }
                    else if (arr[leftIndex] + arr[rightIndex] < arr[tempSumIndex])
                    {
                        leftIndex++;
                    }
                    else
                    {
                        result.Add(new List<int> { arr[leftIndex], arr[rightIndex], arr[tempSumIndex] });
                        leftIndex++;
                    }
                }
                tempSumIndex++;
            }
            return result;
        }
        //using Dictionary O(n) if we have only one sum 

        public static List<List<int>> FindTriplestDictionary(int[] arr)
        {
            List<List<int>> result = new List<List<int>>();
            if (arr.Length < 0) return result;

            Dictionary<int, int> dict = new Dictionary<int, int>();
            int indexForSum = 0;
            int sum;

            while (indexForSum < arr.Length)
            {
                sum = arr[indexForSum];
                for (int i = 0; i < arr.Length; i++)
                {
                    if (dict.ContainsKey(sum - arr[i]))
                    {
                        var newList = new List<int>();
                        newList.Add(arr[indexForSum]);
                        newList.Add(arr[dict[sum - arr[i]]]);
                        newList.Add(arr[i]);
                        result.Add(newList);
                    }
                    dict.Add(arr[i], i);
                }
                dict.Clear();
                indexForSum++;
            }
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine($"{result[i][0]} + {result[i][1]} = {result[i][2]}");
            }
            return result;
        }
    }
}
