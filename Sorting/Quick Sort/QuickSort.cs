using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Sorting.Quick_Sort
{
    /// <summary>
    /// Quick Sort is Divide and Conquer algorithm
    /// It picks an element as a pivot and partition the given array
    /// it's considered as IN-PLACE sorting algorithm
    /// around picked pivot(it can be last/first/random element in array
    /// GENERAL RULE: 1.we pick pivot element(last one for example)
    ///               2.we change elements places that all on the left of pivot is smaller
    ///                 all on the right of pivot is bigger 
    ///               3. we apply recursively same algo to the left side and the right side of the pivot
    /// It reduces the Space Complexity by not using AUXILIARY arr (merge sort does use one)
    /// TC : O(n log(n)) worst O(n^2), it can be avoided
    /// SC : O(log(n))
    /// </summary>
    public class QuickSort
    {
        // s is start index which holds 'border' value and e end index which is iterating the current arr
        public static void QuickSortPlain(int[] arr, int s, int e)
        {
            //this is BASE CASE for recursion
            if(s < e)
            {
                int p = Partition(arr, s, e);
                QuickSortPlain(arr, s, p - 1);
                QuickSortPlain(arr,p + 1, e);
            }
        }

        private static int Partition(int[] arr, int s, int e)
        {
            int pivot = arr[e];
            int pIndex = s;

            //e - 1 cause arr[e] is pivot and we dont want to compare it
            for (int i = 0; i < e -1 ; i++)
            {
                if(arr[i] <= pivot)
                {
                    Swap(arr[i], arr[pIndex]);
                    pIndex++;
                }
            }
            Swap(arr[e], arr[pIndex]);

            return pIndex;

        }

        private static void Swap(int v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
}
