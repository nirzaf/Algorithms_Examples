using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.Sliding_Window
{
    public class Longest_Repeating_Character_Replacement_LC_424
    {
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
    }
}
