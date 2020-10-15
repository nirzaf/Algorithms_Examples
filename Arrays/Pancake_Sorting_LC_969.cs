using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Arrays.LeetCode
{

    /// <summary>
    /// We need to fist find max index of arr then swap it with the begining of arr and swap again with current index
    /// we iterate from the end not start
    /// </summary>
    public class Pancake_Sorting_LC_969
    {
        /// <summary>
        /// TODO: bug in 1st one for sorted array
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static IList<int> PancakeSort(int[] arr)
        {
            var result = new List<int>();
            if (arr == null || arr.Length == 0) return result;
            if (arr.Length == 1) return arr;

            int maxIndex = arr.Length - 1;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (arr[j] > arr[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                if (maxIndex == arr.Length -1) continue;
                Flip(arr, maxIndex + 1);
                Flip(arr, i + 1);
                result.Add(maxIndex + 1);
                result.Add(i + 1);
            }
            return result;
        }
        private static void Flip(int[] arr, int k)
        {
            for (int i = 0; i < k / 2; i++)
            {
                var temp = arr[k - i - 1];
                arr[k - i - 1] = arr[i];
                arr[i] = temp;
            }
        }

        public static IList<int> PancakeSort2(int[] A)
        {

            //
            //This is index 1 based. A[i] is a permutation of [1, 2, ..., A.length]
            //Basically, find the index of Max Value. Reverse it from beginning to maxIndex
            //Add to List the maxIndex from where we flipped.
            //The reverse it so that the max is at the end.
            //Add to List the Index of the Max Element.

            int largest = A.Length;
            List<int> list = new List<int>();

            while (largest >= 1)
            {
                int maxIndex = FindMaxIndex(A, largest);

                Reverse(A, maxIndex);
                list.Add(maxIndex + 1);

                Reverse(A, largest - 1);
                list.Add(largest);

                largest--;
            }
            return list;
        }

        private static int FindMaxIndex(int[] A, int lastIndex)
        {
            int maxIndex = 0;
            for (int i = 1; i < lastIndex; i++)
            {
                if (A[i] > A[maxIndex])
                    maxIndex = i;
            }
            return maxIndex;
        }

        private static void Reverse(int[] A, int maxIndex)
        {
            int startIndex = 0;
            while (startIndex < maxIndex)
            {
                int temp = A[startIndex];
                A[startIndex] = A[maxIndex];
                A[maxIndex] = temp;
                startIndex++;
                maxIndex--;
            }
        }
    }
}
