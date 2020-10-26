using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.Sliding_Window
{
    public class Longest_Repeating_Character_Replacement_LC_424
    {
        /// <summary>
        /// TODO: find brute force, it is sliding window but hard to grasp???
        /// how without decrement k and changing string we know it is less than k??
        /// 
        /// </summary>

        public static int CharacterReplacement(string s, int k)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int[] charCounts = new int[26];
            int end = 0;
            int maxLen = 0;
            int maxCount = 0;

            for (int start = 0; start < s.Length; start++)
            {
                charCounts[s[start] - 'A']++;
                int currentCharCount = charCounts[s[start] - 'A'];
                maxCount = Math.Max(maxCount, currentCharCount);

                // window len - number of chars we dont have to replace
                while (start - end - maxCount + 1 > k)
                {
                    charCounts[s[end] - 'A']--;
                    end++;
                }
                maxLen = Math.Max(maxLen, start - end + 1);
            }
            return maxLen;

        }
//        left: left index thats in window
//        right: right index thats in window
//        count: character count thats in window
//        uniqueCount: count of most unique characters in window
//        replaceCount: number of replacement needed for all characters in window to be the same

//        Each time we expand right, we include a new character in window.
//        If replaceCount is bigger than k, we got an invalid window, we should skip it until window is valid again,
//        but only expands window size, never shrink
//        (because even if we got a smaller window thats valid, it doesnt
//         matter because we already found a window thats bigger and valid)
        public static int CharacterReplacement2(string s, int k)
        {
            int uniqueCount = 0;
            int left = 0;
            int max = 0;
            int[] count = new int[26];
            for (int right = 0; right < s.Length; right++)
            {
                char c = s[right];
                uniqueCount = Math.Max(uniqueCount, ++count[c - 'A']);
                int replaceCount = right - left + 1 - uniqueCount;
                if (replaceCount > k)
                {
                    // invalid window
                    count[s[left++] - 'A']--;
                }
                else
                {
                    max = Math.Max(max, right - left + 1);
                }
            }
            return max;
        }
    }
}
