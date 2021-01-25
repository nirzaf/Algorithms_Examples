using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Sorting.InsertionSort
{
    /// <summary>
    /// Insertion sort in simple terms compare elements.
    /// If element is smaller than element on the left, we swap them.
    /// We swap the element until element on the left is bigger.
    /// Worst Case Time Complexity [ Big-O ]: O(n2)
    /// https://www.interviewbit.com/tutorial/insertion-sort-algorithm/
    /// </summary>
    public class Insertion_sort
    {
        public static int[] InsertionSortPlain(int[] arr)
        {
            for (int i = 1; i < arr.Length; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1], 
                // that are greater than key, 
                // to one position ahead of 
                // their current position 
                while (j >= 0 && arr[j] > key)
                {
                    var temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    j--;
                }
            }
            return arr;
        }
    }
}
