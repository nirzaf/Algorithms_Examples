using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Sorting.BubbleSort
{
    /// <summary>
    /// Goal: sort an array. Here every el is compared with next one thus
    /// every position i will be compared with i+1 in every pass
    /// TC is O(n^2) and SC is 
    /// </summary>
    class BubbleSortPlain
    {
        public static int[] BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                //we dont use i value so it just says how many passes there is
                //it is len - 1 because otherwise it would throw an out of bounds error
                //for len == 8 max j is 6, cause j +1 = 7 which is in bounds
                //OPTIMIZATION: we substract i as well as -1 for each iteration
                //because every time inner loop finish the last elemtnt is at its place
                //so we dont need to take it under consideration :
                //for { 8, 9, 10, 2, 5, 6, 7 } len = 7
                //after 1st full iteration of this loop arr = { 8, 9, 2, 5, 6, 7, 10 } where 10 is moved to 6 index
                //j < 5 (7- 1-1) so the biggest j can get is 4 and j+1 = 5 where arr[4] = 6 ,arr[5] = 7
                //after 2nd full iteration of this loop arr = { 8, 2, 5, 6, 7, 9, 10 } where 9 is moved to 5 index 
                //j < 4 (7- 2-1) so the biggest j can get is 3 and j+1 = 4 where arr[3] = 6, arr[4] = 7 
                //====thus we will be getting one larger element fixed at last position=====
                for (int j = 0; j < arr.Length - i -1; j++)
                {
                    if(arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }
    }
}
