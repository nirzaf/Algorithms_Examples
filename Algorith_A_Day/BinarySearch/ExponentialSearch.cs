using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.BinarySearch
{
    /// <summary>
    /// Goal: searching sorted unbounded/infinite arrays
    /// It's important mostly in huge arrays
    /// Exponectial search used BS in a way that it detrmines RANGE in which the target is.
    /// { 1, 2, 3, 4, 5, 6, 7, 15, 21, 50, 200, 400 } target 21 
    /// the range will be 8/2 for left and 8 so { 5, 6, 7, 15, 21 } 
    /// so binary search(arr, 4, 8, target)
    /// thanks to that its O(log(i)) where i is index of target in arr not like BS O(log(n))
    /// </summary>
    class ExponentialSearch
    {
        public static int BSearch(int[] arr, int left, int right, int target)
        {
            int result = -1;

            while(left <= right)
            {
                int mid = left + (right - left) / 2;

                //base condition
                if (arr[mid] == target) return mid;
                // discard all elements in the left search space
                // including the mid element arr[mid +1, right]
                else if (arr[mid] <= target) left = mid + 1;
                // discard all elements in the right search space
                // including the mid element arr[left, mid -1]
                else right = mid - 1;
            }

            return result;
        }

        public static int ESearch(int[] arr, int target)
        {
            int bound = 1;

            //find the range where target lies
            while(bound < arr.Length && arr[bound] < target)
            {
                bound *= 2;
            }
            //call BS
            return BSearch(arr, bound / 2, Math.Min(bound, arr.Length -1 ), target);
        }
    }
}
