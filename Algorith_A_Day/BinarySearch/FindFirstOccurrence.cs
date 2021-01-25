using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.BinarySearch
{
    /// <summary>
    /// Goal here is to find first or last occurrence(index) of given number in arr
    /// 
    /// 
    /// mid = left + (right - left) / 2 it is safe to calculate mid like this with many rekords
    /// 
    ///
    /// </summary>
    /// <returns>index not actual value</returns>
    public class FindFirstOccurrence
    {
         //{2, 2, 2, 2, 5, 6, 8, 10, 10, 10 }
        public int FindFirst(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;
            int firstOccurence = -1;

            while(left <= right)
            {
                int mid = (left + right) / 2;


                //check if el at mid index is equal to target
                //if yes we assign mid to firstOccurence
                if (arr[mid] == target)
                {
                    firstOccurence = mid;
                    right = mid - 1;//it is not rotated so right is nit important
                }
                else if (arr[mid] > target) right = mid - 1;
                else left = mid + 1; //(arr[mid] < target)
            }
            return firstOccurence;

        }

        public int FindLast(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;
            int result = -1;

            while(left <= right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] == target)
                {
                    result = mid;
                    left = mid + 1;
                }
                else if (arr[mid] < target) left = mid + 1;
                else right = mid - 1;

            }
            return result;
        }
    }
}
