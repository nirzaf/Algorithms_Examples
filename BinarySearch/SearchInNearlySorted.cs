using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.BinarySearch
{
    /// <summary>
    /// Goal: search for el in nearly sorted array(el is +- 1 from corect order)
    /// { 2,1,3,5,4,7,6,8,9 } target 5 index 3
    /// { 2,1,3,5,4,7,6,8,9 } target 10 index -1
    /// The idea here is to compare targer with arr[mid-1] and arr[mid +1] 
    /// </summary>
    public class SearchInNearlySorted 
    {
        public static int GetFromNS(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while(left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target) return mid;
                else if (arr[mid - 1] == target && mid - 1 >= left)
                {
                    return mid - 1;
                }
                else if (arr[mid + 1] == target && mid + 1 <= right)
                {
                    return mid + 1;
                }
                //mid el and +- elements are not target so we reduce search space
                //target is bigger than arr[mid] so we search i right subarray
                //(mid + 2) cause we already checked arr[mid+1]
                else if (target > arr[mid])
                {
                    left = mid + 2;
                }
                //mid el and +- elements are not target so we reduce search space
                //target is smaller than arr[mid] so we search i left subarray
                //(mid - 2) cause we already checked arr[mid-1]
                else
                {
                    right = mid - 2;
                }
            }

            return -1;
        } 
    }
}
