using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.Sliding_Window
{
    public class Sliding_Window
    {
        /// <summary>
        /// Goal: Find the average of all contiguous subarrays of size ‘K’ in it.
        /// Array: [1, 3, 2, 6, -1, 4, 1, 8, 2], K=5
        /// For the first 5 numbers (subarray from index 0-4), the average is: (1+3+2+6-1)/5 => 2.2(1+3+2+6−1)/5=>2.2
        /// The average of next 5 numbers(subarray from index 1-5) is: (3+2+6-1+4)/5 => 2.8(3+2+6−1+4)/5=>2.8
        /// https://www.educative.io/courses/grokking-the-coding-interview/7D5NNZWQ8Wr
        /// </summary>

        // TC - O(N*K) where N is number in arr
        public static double[] GetAverageSubArraysSizeKNaive(int K, int[] arr)
        {
            var result = new double[arr.Length - K + 1];

            //less or equal because it has to take el at index 4 so 5th el (len -K)
            for (int i = 0; i <= arr.Length - K; i++)
            {
                double currentSum = 0;
                for (int j = i; j < i + K ; j++)
                {
                    currentSum += arr[j];
                }
                result[i] =  currentSum / K;
            }
            return result;
        }

        //here we get the sum of K elements and then substract from sum first element and add the next one (from loop index)
        // TC - O(N)
        public static double[] GetAverageSubArraysSizeK(int K, int[] arr)
        {
            var result = new double[arr.Length - K + 1];
            double currentSum = 0.0;
            int windowStart = 0;

            for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                currentSum += arr[windowEnd];

                if(windowEnd >=K - 1)
                {
                    result[windowStart] = currentSum / K;
                    currentSum -= arr[windowStart];
                    windowStart++;
                }
            }
            return result;
        }
    }
}
