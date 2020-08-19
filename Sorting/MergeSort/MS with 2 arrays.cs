using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Sorting.MergeSort
{
    public class MS_with_2_arrays
    {
        public static void MergeSort2(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = (l + r)  / 2;

                MergeSort2(arr, l, m);
                MergeSort2(arr, m + 1, r);
                Merge(arr, l, m, r);
            }
        }

        private static void Merge(int[] arr, int l, int m, int r)
        {
            int i, j, k;
            int n1 = m - l + 1;
            int n2 = r - m;

            var L = new int[n1];
            var R = new int[n2];

            for (i = 0; i < n1; i++)
            {
                L[i] = arr[l + 1];
            }
            
            for (j = 0; j < n2; j++)
            {
                R[j] = arr[m + 1 +j];
            }
            i = 0;
            j = 0;
            k = l;

            while(i < n1 && j < n2)
            {
                if(L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
    }
}
