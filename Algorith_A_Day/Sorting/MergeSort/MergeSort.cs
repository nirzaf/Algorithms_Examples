using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Sorting.MergeSort
{
    /// <summary>
    /// Divide and Conquer algorithm
    /// IT IS NOT IN PLACE ALGO becuse it uses aux data structure(array)
    /// every recursion call it divide current array into 2 parts 
    /// Until its only one element in given arr then the element are compared and merge as a sorted subarr
    /// TC : O(n log(n)) very effective algorithm
    /// SC : O(n)
    /// https://www.quora.com/Algorithms-How-does-merge-sort-have-space-complexity-O-n-for-worst-case
    /// </summary>
    public class MergeSort
    {
        public static void MergeSortPlain(int[] arr, int start, int end)
        {
            if(end > start)
            {
                //middle el
                int m = (start + end) / 2;
                //NOT m - 1 because we want el at index m too in case of odd number of elements
                MergeSortPlain(arr, start, m);
                MergeSortPlain(arr, m + 1, end);
                Merge(arr, start, m, end);
            }
        }

        private static void Merge(int[] arr, int start, int mid, int end)
        {
            int i = start;     //first el at the left subarray
            int j = mid + 1; //first el at the right subarray
            int k = 0;     //k is index pointer for temp arr

            var temp = new int[(end - start )+ 1];

            //2 arrays here left subarray [i...m] and right subarray [j...e]

            //it checks boundaries ranges for both subarries
            while (i <= mid && j <= end)
            {
                //element in left arr is smaller and goes to temp
                if(arr[i] <= arr[j])
                {
                    temp[k] = arr[i];
                    i++;
                    k++;
                }
                //element in right arr is smaller and goes to temp
                else
                {
                    temp[k] = arr[j];
                    j++;
                    k++;
                }
            }//END OF WHILE

            //there are some el left in  left in left subarray
            // and can be transfer to temp without comaparing (they are sorted already)
            while (i <= mid)
            {
                temp[k] = arr[i];
                i++;
                k++;
            }
            //there are some el left in right in left subarray
            // and can be transfer to temp without comaparing (they are sorted already
            while (j <= end)
            {
                temp[k] = arr[j];
                j++;
                k++;
            }

            //copy temp arr to original arr
            // arr[p] cause we need to change orginal array from the index of current start(e.x 3)
            // temp[p-s] cause we always initailize temp from 0 index so for s = 3, 3-3 , 4 - 3, 5 -3 so 0,1,2
            // so we take index in middle of orginal and set from BEGGINGIN of temp
            for (int p = start; p <= end; p++)
            {
                arr[p] = temp[p -start];
            }
        }
    }
}
