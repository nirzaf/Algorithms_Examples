using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.Sliding_Window
{
    public class Permutation_in_String_LC_567
    {
        //slow my solution
        public static bool CheckInclusion(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2)) return false;
            int len = s1.Length;
            var map = new Dictionary<char, int>();
            bool result = false;

            int start = 0;
            int end = len-1;
            for (int i = 0; i < len; i++)
            {
                if (!map.ContainsKey(s1[i]))
                {
                    map.Add(s1[i], 1);
                }
                else
                {
                    map[s1[i]]++;
                }
                //bbabc a:1 b:3 c:1  bbbac cabbb
            }

            while(end < s2.Length)
            {
                string substring = s2.Substring(start, len);

                result = CheckIfContains(substring, map);
                if (result == true) return true;
                end++;
                start++;
            }
            return result;
        }
        private static bool CheckIfContains(string substring, Dictionary<char, int> map )
        {
            var map2 = new Dictionary<char, int>();

            for (int i = 0; i < substring.Length; i++)
            {
                if (!map2.ContainsKey(substring[i]))
                {
                    map2.Add(substring[i], 1);
                }
                else
                {
                    map2[substring[i]]++;
                }
                //bbabc a:1 b:3 c:1  bbbac cabbb
            }
            foreach (var item in map2)
            {
                if(!map.ContainsKey(item.Key) || !(map[item.Key] == map2[item.Key]))
                {
                    return false;
                }

            }
            return true;
        }

        public static bool CheckInclusion2(string s1, string s2)
        {
            int[] s1Frequency = getFrequency(s1);
            //int[] s2Frequency = getFrequency(s2);

            bool result = false;
            if (s1.Length <= s2.Length)
            {
                result = check(s2, s1Frequency, s1.Length);
            }

            return result;
        }

        // it is ascii a = 97  b = 98 c = 99 d = 100 
        // so if we substract a we get array where index 0 = a, 1 = b 2 = 3
        private static int[] getFrequency(string s)
        {
            int[] frequency = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                var x = s[i] - 'a';
                var z = 'd' - 'a';
                frequency[s[i] - 'a']++;
            }
            return frequency;
        }

        private static bool compare(int[] frequency1, int[] frequency2)
        {
            for (int i = 0; i < 26; i++)
            {
                if (frequency1[i] != frequency2[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool check(string s, int[] s2Frequency, int length)
        {
            int[] frequency = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                frequency[s[i] - 'a']++;

                if (compare(frequency, s2Frequency))
                {
                    return true;
                }

                //check if we have the same number of letters(as the goal string) in frequency
                // for "dad", "bbacdoadd" bba are in frequency
                // if yes we decrement the letter from frequency, s[2 - 3 + 1] - 'a' = 'b' - 'a' = 1 
                //frequency[1]-- so basically we move window in that way to the right
                if (i >= length - 1)
                {
                    frequency[s[i - length + 1] - 'a']--;
                }
            }

            return false;
        }
    }
}
