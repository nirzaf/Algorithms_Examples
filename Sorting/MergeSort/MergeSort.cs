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
        public static void MergeSortPlain(int[] arr, int s, int e)
        {
            if(e > s)
            {
                //middle el
                int m = (s + e) / 2;
                //NOT m - 1 because we want el at index m too in case of odd number of elements
                MergeSortPlain(arr, s, m);
                MergeSortPlain(arr, m + 1, e);
                Merge(arr, s, m, e);
            }
        }

        private static void Merge(int[] arr, int s, int m, int e)
        {
            int i = s;
            int j = m + 1;
            int k = s; //k is index pointer for temp arr

            var temp = new int[arr.Length];

            //2 arrays here left subarray [i...m] and right subarray [j...e]

            //it checks boundaries ranges for both subarries
            while (i <= m && j <= e)
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
            while (i <= m)
            {
                temp[k] = arr[i];
                i++;
                k++;
            }
            //there are some el left in right in left subarray
            // and can be transfer to temp without comaparing (they are sorted already
            while (j <= e)
            {
                temp[k] = arr[j];
                j++;
                k++;
            }

            //copy temp arr to original arr
            for (int p = s; p <= e; p++)
            {
                arr[p] = temp[p];
            }
        }
    }
}
