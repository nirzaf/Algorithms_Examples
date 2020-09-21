using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.ModifiedBinarySearch
{
    public class Binary_Search_LC_704
    {
        public static int Search(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;
            if (nums.Length == 1) return 0;

            int left = 0;
            int right = nums.Length -1;
            // in case of int overflow
            int mid = left + (right - left) / 2; 

            while(left <= right)
            {
                if (nums[mid] == target) return mid;
                else if(nums[mid] > target)
                {
                    right = mid -1;
                }
                else
                {
                    left = mid + 1;
                }
                mid = left + (right - left) / 2;
            }
            return -1;
        }

    }
}
