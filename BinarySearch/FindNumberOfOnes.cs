using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Algorithm_A_Day.BinarySearch
{
    /// <summary>
    /// Goal: Given sorted binary array find number of 1s
    /// 
    /// Idea: Find accurance of first 1 and substract its index from len of arr
    /// { 0, 0, 0, 0, 1, 1, 1 } 3
    /// { 0, 0, 1, 1, 1, 1, 1 } 5
    /// 
    /// </summary>
    public class FindNumberOfOnes
    {
        //iteratively
        public static int FindOnes(int[] arr)
        {
            int firstOccurance = -1;
            int left = 0;
            int right = arr.Length - 1;

            //if last el is 0 all the rest is 0 so no 1s
            if (arr[right] == 0) return 0;
            //if first el is 1 all the rest are 1s
            //so return arr.lenght since its sorted
            if (arr[left] == 1) return right - left + 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == 1)
                {
                    firstOccurance = mid;
                    right = mid - 1;
                    
                } 
                else
                {
                    left = mid + 1;
                }
            }
            return arr.Length - firstOccurance;
        }
        
        //recursively
        public static int FindOnesRecur(int[] arr, int left, int right)
        {
            if (arr[right] == 0) return 0;
            if (arr[left] == 1) return right + left +1;


            if (left > right) return arr.Length - left;
            int mid = left + (right - left) / 2;


            if (arr[mid] == 1)
            {
                return FindOnesRecur(arr, left, mid - 1);
            }
            else
            {
                return FindOnesRecur(arr, mid + 1, right);
            }
        } 
        
        //recur diff approach
        public static int FindOnesRecur2(int[] arr, int left, int right)
        {
            //base cases
            if (arr[right] == 0) return 0;
            if (arr[left] == 1) return right - left +1;

            int mid = left + (right - left) / 2;

            //we split arr into 2 halves and recur for both halves
            return FindOnesRecur2(arr, left, mid) + FindOnesRecur2(arr, mid + 1, right);
        }
    }
}
