using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Sorting.SelectionSort
{
    /// <summary>
    /// Selection sort is IN-PLACE sort.
    /// It is build from left to right.
    /// Genral rules: 1.Compare first el to the rest and swap it with the smallest,
    ///                 1.5 in other words from the rest indexes compare the one vales chose one and swap it with choses first element 
    ///               2. Change the first el to the next 
    ///               3. step 1 and 2 again utnil the el at arr.len -2 as last el is sorted automatically
    ///               4. outer loop is for setting the current elemnt to compare and innner is for comparing
    /// TC - O(n^2) so inefficient on large lists
    /// </summary>
    public class SelectionSort
    {
        public static int[] SelectionSortPlain(int[] arr)
        {
            // it is arr.Length -1 because the last el left is on its place
            // and we comper next el
            for (int i = 0; i < arr.Length -1; i++)
            {
                var min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                //if min == i that means we dont have swap because no chang was made
                // min != i that means there is an smaller el than current one and a swap is needed
                if (min != i)
                {
                    var temp = arr[min];
                    arr[min] = arr[i];
                    arr[i] = temp;
                }
            }
            return arr;
        }
    }
}
