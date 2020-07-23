using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.BinarySearch
{
    /// <summary>
    /// Goal: Find a peak element of an array (not smaller than neighbours)
    /// peak is an el bigger than the next and prev (or first/last el respectively) 
    /// arr can have multiple peaks we want any
    /// 
    /// here we use idea similar to BS not exactly itself
    /// recursive solution time complexity is O(log(n))
    /// </summary>
    public class FindPeakElement
    {
        //resursively
        public static int FindPeakRecur(int[] arr, int left, int right)
        {
            int mid = left + (right - left) / 2;
            
            //base case we check if mid el is greater than neighbours
            //it takes care of special cases of last and first el
            if((mid == 0 || arr[mid -1] <= arr[mid]) &&
                (mid == arr.Length -1 || arr[mid + 1] <= arr[mid]))
            {
                return mid;
            }
            //if left el of mid is greater than mid 
            //we seatch in left sub-array
            if (mid - 1 >= 0 && arr[mid - 1] > arr[mid])
                return FindPeakRecur(arr, left, mid - 1);

            //if right el of mid is greater than mid 
            //we seatch in right sub-array 
            return FindPeakRecur(arr, mid + 1, right);

        }
        
        //interatively
        public static int FindPeakIter(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;
            int mid = left + (right - left) / 2;

            int prev = arr[mid - 1];
            int next = arr[mid + 1];

            return -1;
        }
    }
}
