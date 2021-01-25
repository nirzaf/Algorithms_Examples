using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Sorting.BubbleSort
{
    /// <summary>
    /// Leetcode 75. Sort Colors
    /// Given an array with n numbers 0, 1 or 2,
    /// sort them in-place so that numbers of the same value are adjacent,
    /// for { 2, 0, 2, 1, 1, 0 } its { 0, 0, 1, 1, 2, 2 }
    /// I can be solved by any sorting algo here bubble sort 
    /// </summary>
    class SortColors
    {
        public static void SortColorsMethod(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length - 1 - i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        int temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                    }
                }
            }
        }
    }
}
