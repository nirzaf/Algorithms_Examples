using Algorithm_A_Day.Arrays.Mix;
using Algorithm_A_Day.BinarySearch;
using Algorithm_A_Day.Grid_Based;
using Algorithm_A_Day.Patterns.Sliding_Window;
using Algorithm_A_Day.Sorting.BubbleSort;
using Algorithm_A_Day.String_operations;
using System;
using System.Diagnostics.Tracing;
using System.Linq;

namespace Algorith_A_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            var testArr = new int[] { 4,1 };
            var sortedArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 15, 21, 50, 200, 400 };
            var mixedArr = new int[] { 2, 1, 5, 10, 3, 2 };

            string[] fruits = { "grape", "passionfruit", "banana", "mango",
                      "orange", "raspberry", "apple", "blueberry" };


            Pairs_with_Specific_Difference___pramp.FindPairsWithGivenDifference3(testArr, 3);
            Sliding_Window.GetAverageSubArraysSizeK(5, mixedArr);

            //Smallest_Subarray_with_a_given_sum.findMinSubArray(7, mixedArr);
            Longest_Substring_with_K_Distinct_Characters.FindLength("araaci", 2);


        }

        //naive solution
        public static int Yesterdays(int S, int[] arr)
        {
            int currentSum = 0;
            int minSize = int.MaxValue;
            int start = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                currentSum += arr[i];
                
                while(currentSum >= S)
                {
                    minSize = Math.Min(i - start + 1, minSize);
                    currentSum -= arr[start];
                    start++;
                }
            }

            return minSize == int.MaxValue ? 0 : minSize;
        }
        //sliding widow
        //public static double[] Yesterdays2(int K, int[] arr)
        //{


        //}

    }
}
