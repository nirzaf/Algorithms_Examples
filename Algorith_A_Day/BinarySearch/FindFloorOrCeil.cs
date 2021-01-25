using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.BinarySearch
{
    /// <summary>
    /// Goal: find floor or ceil of a given number in sorted arr of integers.
    /// {1, 4, 6, 8, 9 }
    /// 0 ceiling = 1, floor -1 because it is not in arr
    /// 2 ceiling = 4, floor 1 
    /// 5 ceiling = 6, floor 4 
    /// 9 ceiling = 9, floor 9 
    /// 10 ceiling = -1, floor 9 -1 because it is not in arr 
    /// 
    /// For ceiling it is the smallest int in arr but >= target
    /// For floor it is the largest int in arr but  <= target
    /// 
    /// https://www.techiedelight.com/find-floor-ceil-number-sorted-array/
    /// </summary>
    public class FindFloorOrCeil
    {
        public int GetCeil(int[] arr, int target)
        {
            int result = -1;
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target) result = arr[mid];

                if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else// (arr[mid] > target)
                {
                    result = arr[mid];
                    right = mid - 1;
                }

            }
            return result;
        }

        //{1, 4, 6, 8, 9 }
    public int GetFloor(int[] arr, int target)
        {
            int result = -1;
            int left = 0;
            int right = arr.Length - 1;

            while(left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target) result = arr[mid];
                else if(arr[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    result = arr[mid];
                    left = mid + 1;
                }
            }
            return result;
        }
    }
}
