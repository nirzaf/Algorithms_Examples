using Algorithm_A_Day.Arrays.Mix;
using Algorithm_A_Day.BinarySearch;
using Algorithm_A_Day.Grid_Based;
using Algorithm_A_Day.Patterns.Sliding_Window;
using Algorithm_A_Day.Sorting.BubbleSort;
using Algorithm_A_Day.Sorting.InsertionSort;
using Algorithm_A_Day.Sorting.MergeSort;
using Algorithm_A_Day.Sorting.Quick_Sort;
using Algorithm_A_Day.Sorting.SelectionSort;
using Algorithm_A_Day.String_operations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO.Pipes;
using System.Linq;
using System.Net.Sockets;

namespace Algorith_A_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            var testArr = new int[] { 4, 1 };
            var sortedArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 15, 21, 50, 200, 400 };
            var mixedArr = new int[] { 6, 7, 2, 1, 5, 3 };

            string[] fruits = { "grape", "passionfruit", "banana", "mango",
                      "orange", "raspberry", "apple", "blueberry" };


            //Pairs_with_Specific_Difference___pramp.FindPairsWithGivenDifference3(mixedArr, 1);
            //Sliding_Window.GetAverageSubArraysSizeK(5, mixedArr);

            //Smallest_Subarray_with_a_given_sum.findMinSubArray(7, mixedArr);
            //Longest_Substring_with_K_Distinct_Characters.FindLength("cbbebi", 3);

            Yesterdays(mixedArr);

            //Insertion_sort.InsertionSortPlain(mixedArr);
            //QuickSort.QuickSortPlain(mixedArr, 0, mixedArr.Length - 1);
            //SelectionSort.SelectionSortPlain(mixedArr);
            //MergeSort.MergeSortPlain(mixedArr, 0, mixedArr.Length -1);

        }
        //  0  1  2  3  4  5
        //{ 2, 1, 5, 6, 7, 3 };
        //{ 6, 7, 2, 1, 5, 3 };

        //naive solution
        public static void Yesterdays(int[] arr)
        {
            
        }

        //private static int Example(int[] arr, int s, int e)
        //{
            
        //}
    }
}
