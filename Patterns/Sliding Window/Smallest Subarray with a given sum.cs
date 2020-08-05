using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.Sliding_Window
{
    /// <summary>
    /// Given an array of positive numbers and a positive number ‘S’,
    /// find the length of the smallest contiguous subarray whose sum is greater than or equal to ‘S’.
    /// Return 0, if no such subarray exists.
    /// Input: [2, 1, 5, 2, 3, 2], S=7 
    /// Output: 2
    /// The smallest subarray with a sum great than or equal to '7' is [5, 2].
    /// for { 2, 1, 5, 10, 3, 2 } s = 7 ; solution is [10];
    /// in that case first min is 3  [2,1,5] = 8 and 8 >= 7,
    /// then in while loop we substract first el and increment it by 1;
    /// [1,5] = 6 and 6 < 7, so we add next element [1,5,10] = 16 >= 7 so we enter while loop 
    /// min len is still 3 we substruct alement at index start(1) 
    /// so now [5,10] = 15  >= 7 so we DONT exit loop; min is (3, 3-2+1) = 2
    /// we substract 5 and incremants start so [10] >= 7, now windownStart == windowsEnd
    /// we DONT exit loop; min is (3, 3-2+1) = 1, substract 10 so sum is 0 
    /// next we do the same with last 2 elements but they are summing up to s
    /// </summary>
    public class Smallest_Subarray_with_a_given_sum
    {
        //TC O(N+N) which is asymptotically equivalent to O(N)
        public static int FindMinSubArray(int S, int[] arr)
        {
            int windowSum = 0, minLength = int.MaxValue;
            int windowStart = 0;
            for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                windowSum += arr[windowEnd]; // add the next element
               
                // shrink the window as small as possible until the 'windowSum' is smaller than 'S'
                while (windowSum >= S)
                {
                    minLength = Math.Min(minLength, windowEnd - windowStart + 1);
                    windowSum -= arr[windowStart]; // subtract the element going out
                    windowStart++; // slide the window ahead
                }
            }

            return minLength == int.MaxValue ? 0 : minLength;
        }
    }
}
