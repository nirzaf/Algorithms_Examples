using Algorithm_A_Day.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace Algorithm_A_Day.Patterns.Sliding_Window
{
    public class Longest_Substring_with_K_Distinct_Characters
    {
        public static int FindLength(string str, int k)
        {
            if (str.Length == 0 || str == null || str.Length < k) return 0;

            IDictionary<char, int> charFrequencyMap = new Dictionary<char, int>();

            int maxLen = 0;
            int windowStart = 0;

            // in the following loop we'll try to extend the range [windowStart, windowEnd]
            for (int windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                char rightChar = str[windowEnd];
                if (charFrequencyMap.ContainsKey(rightChar))
                {
                    charFrequencyMap[rightChar]++;
                }
                else charFrequencyMap.Add(rightChar, 1);

                // shrink the sliding window, until we are left with 'k' distinct characters in the frequency map
                while (charFrequencyMap.Count > k)
                {
                    char leftChar = str[windowStart];
                    if (charFrequencyMap.ContainsKey(leftChar))
                    {
                        charFrequencyMap[leftChar]--;
                    }
                    else charFrequencyMap.Add(leftChar, 1);
                    //charFrequencyMap.Add(leftChar, charFrequencyMap[leftChar] - 1);
                    if (charFrequencyMap[leftChar] == 0)
                    {
                        charFrequencyMap.Remove(leftChar);
                    }
                    windowStart++; // shrink the window
                }
                maxLen = Math.Max(maxLen, windowEnd - windowStart + 1); // remember the maximum length so far
            }

            return maxLen;

        }

        //if (str.Length == 0 || K <= 0) return 0;

        //    var dict = new Dictionary<char, int>();
        //var longest = int.MinValue;
        //int start = 0;

        //    for (int i = 0; i<str.Length; i++)
        //    {
        //        if (!dict.ContainsKey(str[i]))
        //        {
        //            dict.Add(str[i], 1);
        //        }
        //        else
        //        {
        //            dict[str[i]]++;
        //        }

                

        //        while (dict.Count > K)
        //        {
                    
        //            dict[str[start]]--;
                    
        //            if(dict[str[start]] == 0)
        //            {
        //                dict.Remove(str[start]);
        //            }
        //            start++;
                    

        //        }
                
        //        longest = Math.Max(longest, i - start + 1);
        //    }
        //    return longest;

    }      
}

