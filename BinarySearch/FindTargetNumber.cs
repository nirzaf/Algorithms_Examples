using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Algorithm_A_Day.BinarySearch
{   /// <summary>
    /// Goal is to find int target in rotated sorted array
    /// Most important here is to understand there is a pivot element
    /// 1.it divides arr in 2 sorted halfs 2. is always less than next and prev el to it.
    /// Firstly we need to check which part is sorted.
    /// Then check if target is in range of the sorted part
    /// if not do the same again for the opposite side with changed start and end of the array
    /// </summary>
    class FindTargetNumber
    {
        public int FindNumber(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                //if el at mid is targer return mid index
                if (arr[mid] == target) return mid;

                //if right half [mid..right] is sorted and mid is not 
                //the target  {14, 18, 21, 3, 6, 8, 9, 12} 3 < 12

                if (arr[mid] <= arr[right])
                {
                    //compare target with arr[mid] and arr[right]
                    //to find if it lies in arr[mid..right]
                    if (target > arr[mid] && target <= arr[right])
                        left = mid + 1; //searching in the right sorted half
                    else
                        right = mid - 1;//go search left in arr[left...mid-1]
                                        //it can be sorted/unsorted
                }

                //if left half [left..mid] is sorted and mid is not 
                //the target {12, 14, 18, 21, 3, 6, 8, 9} 21 > 12

                else //(arr[mid] >= arr[left]
                {
                    //compare target with arr[mid] and arr[left]
                    //to find if it lies in arr[left..mid]
                    if (target < arr[mid] && target >= arr[left])
                        right = mid - 1;//searching in the left sorted half
                    else
                        left = mid + 1;//go search right in [mid +1..right]
                                       //it can be sorted/unsorted
                }
            }
            return -1;
        }
        
    }
}
