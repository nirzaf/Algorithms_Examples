using Algorithm_A_Day.Arrays.Mix;
using Algorithm_A_Day.BinarySearch;
using Algorithm_A_Day.Grid_Based;
using Algorithm_A_Day.Patterns._2Pointers;
using Algorithm_A_Day.Patterns.Sliding_Window;
using Algorithm_A_Day.Sorting;
using Algorithm_A_Day.Sorting.MergeSort;
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
            var testArr = new int[] { 1, 2, 3, 4,  };
            var sortedArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 15, 21, 50, 200, 400 };
            var mixedArr = new int[] { 0, 1, 2, 3, 11 };

            string[] fruits = { "grape", "passionfruit", "banana", "mango",
                      "orange", "raspberry", "apple", "blueberry" };

            //Yesterdays(mixedArr);
            MS_with_2_arrays.MergeSort2(mixedArr, 0 , mixedArr.Length -1);
            //Intersection.IntersectionMethod(testArr, mixedArr);
            //Squares_of_a_Sorted_Array___LeedCode_977.SortedSquares(mixedArr);
        }
        //  0  1  2  3  4  5
        //{ 2, 1, 5, 6, 7, 3 };
        //{ 6, 7, 2, 1, 5, 3 };

        //naive solution
        public static void Yesterdays(int[] arr, int s, int e)
        {
            //base case
            if (s < e)
            {
                int m = (s + e) / 2;
                Yesterdays(arr, s, m);
                Yesterdays(arr, m + 1, e);
                Example(arr, s, m, e);
            }
        }

        private static void Example(int[] arr, int s, int m, int e)
        {
            int i = s, j = m + 1 ;
            int k = s;
            int[] temp = new int[arr.Length];

            //main loop
            while (i <= m && j <= e)
            {
                if(arr[i] <= arr[j])
                {
                    temp[k] = arr[i];
                    i++;
                    k++;
                }
                else
                {
                    temp[k] = arr[j];
                    i++;
                    k++;
                }
            }

            while (i <= m)
            {
                temp[k] = arr[i];
                i++;
                k++;
            }
            while (j <= e)
            {
                temp[k] = arr[j];
                j++;
                k++;
            }

            for (int p = s; p < e; p++)
            {
                arr[p] = temp[p];
            }
        }

    }
}
