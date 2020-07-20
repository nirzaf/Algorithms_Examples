using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.BinarySearch
{
    /// <summary>
    /// Goal: Find smallest missing element in arr where arr[i] == i, sorted and distinct non-negative
    /// [0,1,2,6,9,11,15] --> 3 
    /// [1,2,3,4,6,9,11,15] --> 0
    /// 
    /// We can deduct that SME will be the index of first el which is not equal to its value. so arr[i] != i
    /// https://www.techiedelight.com/find-smallest-missing-element-sorted-array/
    /// </summary>
    public class SmallestMissingElement
    {
        public int SmallestMissingEL(int[] arr, int left, int right)
        {
            //base condition
            if (left > right) return left;

            int mid = left + (right - left) / 2;

            //if mid index is equal its element that means all left from mid is sorted
            //and there is no missing elements, SME must be on the right
            if(arr[mid] == mid)
            {
                return SmallestMissingEL(arr, mid + 1, right);
            }
            else //SME must be on left
            {
                return SmallestMissingEL(arr, left, mid - 1); 
            }
        }
    }
}

//Recursion section:
//stack is being used so calls are from botton to the top

//{ 0, 1, 2, 3, 4, 5, 6 }

//SmallestMissingEL(int[] arr, 7, 6) mid ==6 ,arr[mid] != mid, 7 > 6 base call is true 7 is returned
//SmallestMissingEL(int[] arr, 6, 6) mid ==6 ,arr[mid] == mid
//SmallestMissingEL(int[] arr, 5, 6) mid ==5 ,arr[mid] == mid
//SmallestMissingEL(int[] arr, 4, 6) mid ==5 ,arr[mid] == mid
//SmallestMissingEL(int[] arr, 0, 6) first call, mid ==3 ,arr[mid] == mid 

//{ 1, 2, 3, 4, 5, 6 }

//SmallestMissingEL(int[] arr, 0, -1) mid ==0 ,arr[mid] == mid, 0> -1 base call is true 0 is returned
//SmallestMissingEL(int[] arr, 0, 1) mid ==0 ,arr[mid] != mid
//SmallestMissingEL(int[] arr, 0, 5) first call, mid ==2 ,arr[mid] != mid 

//{ 0, 1, 2, 6, 9, 11, 15 }
//SmallestMissingEL(int[] arr, 3, 2) 3> 2 base call is true 3 is returned
//SmallestMissingEL(int[] arr, 2, 2) mid ==2 ,arr[mid] == mid
//SmallestMissingEL(int[] arr, 0, 2) mid ==1 ,arr[mid] == mid arr[1] == 1, !!!
//SmallestMissingEL(int[] arr, 0, 6) first call, mid ==3 ,arr[mid] != mid 

