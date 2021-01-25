using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns._2Pointers
{
    public class Squares_of_a_Sorted_Array___LeedCode_977
    {
        public static int[] GetSquares(int[] arr)
        {
            var result = new int[arr.Length];

            int left = 0;
            int right = arr.Length -1;
            int k = arr.Length -1;

            while(left <= right)
            {
                if (arr[left] * arr[left] < arr[right] * arr[right])
                {
                    result[k] = arr[right] * arr[right];
                    k--;
                    right--;
                }
                else
                {
                    result[k] = arr[left] * arr[left];
                    k--;
                    left++;

                }
            }
            return result;
        }
        //{ -7, -3, 2, 3, 11 }
        public static int[] SortedSquares(int[] A)
        {
            //orginal arr len
            int N = A.Length;
            // index of first positive value  
            int j = 0;
            // purpose of this loop = [j...N] where every el is positive 
            while (j < N && A[j] < 0)
                j++;
            // index of first negative value  
            int i = j - 1;

            int[] ans = new int[N];
            int t = 0;

            // it looks like this [...ij...] so we can only decrease i and increase j
            // i >= 0 meaning i Index not the value, if i = 1 then 2 negative numbers in arr
            // j< N j cannot be bigger than array len
            while (i >= 0 && j < N)
            {
                //if first sq negative value is smaller than first smallest positive then it haas to be the smallest in new arr
                if (A[i] * A[i] < A[j] * A[j])
                {
                    ans[t++] = A[i] * A[i];
                    i--;
                }
                else
                {
                    ans[t++] = A[j] * A[j];
                    j++;
                }
            }
            //if any negative values left
            while (i >= 0)
            {
                ans[t++] = A[i] * A[i];
                i--;
            }
            //if any n values left

            while (j < N)
            {
                ans[t++] = A[j] * A[j];
                j++;
            }

            return ans;
        }
    }
}
