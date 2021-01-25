using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.Sliding_Window
{
    public class Longest_Substring_Without_Repeating_Characters_LC_3
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0) return 0;
            if (s.Length == 1) return 1;

            int result = int.MinValue;
            var dict = new Dictionary<char, int>();
            int start = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    start = Math.Max(dict[s[i]], start);
                }
                result = Math.Max(result, i - start + 1);
                dict[s[i]] = i + 1;
            }

            return result == int.MinValue ? 0 : result;
        }
    }
}
