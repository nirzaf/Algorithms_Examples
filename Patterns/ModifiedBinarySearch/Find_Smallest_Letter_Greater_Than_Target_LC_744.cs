using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.ModifiedBinarySearch
{
    public class Find_Smallest_Letter_Greater_Than_Target_LC_744
    {
        /// <summary>
        /// with modulo
        /// </summary>

        public static char NextGreatestLetter(char[] letters, char target)
        {
            // Get ready initial state
            int lo = 0, hi = letters.Length - 1;
            // Loop while boundaries are correct
            while (hi >= lo)
            {
                // Find median of the array
                int mi = lo + (hi - lo) / 2;
                // Compare target and median
                if (letters[mi] > target)
                {
                    // Looks like the answer in the left sub-array
                    hi = mi - 1;
                }
                else
                {
                    // Looks like the answer in the right sub-array
                    lo = mi + 1;
                }
            }
            // Wrap around the array when max exceeds its length
            return letters[Math.Max(lo, hi) % letters.Length];
        }
        /// <summary>
        /// no modulo
        /// </summary>

        public char NextGreatestLetter1(char[] letters, char target)
        {
            int n = letters.Length;
            if (target >= letters[n - 1]) return letters[0];

            int left = 0;
            int right = n - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (letters[mid] <= target) left = mid + 1;
                else right = mid;
            }

            return letters[right];
        }

        /// <summary>
        /// it is sorted so first element largest is the answer otherwise 
        /// wrapup feature means it first el 
        /// </summary>

        public static char NextGreatestLetter2(char[] letters, char target)
        {
            foreach (var l in letters)
            {
                if (l > target) return l;
            }
            return letters[0];
        }

        public char NextGreatestLetter3(char[] letters, char target)
        {
            int[] characters = new int[26];

            for (int i = 0; i < letters.Length; i++)
                characters[letters[i] - (int)'a']++;

            for (int i = ((int)(target) - 'a') + 1; i < characters.Length + 1; i++)
            {
                if (i >= characters.Length)
                    i = 0;

                if (characters[i] > 0)
                    return (char)(i + (int)'a');
            }

            return 'a'; //never going to reach this
        }
    }
}
