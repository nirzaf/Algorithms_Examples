using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.String_operations
{
    public class Implement_strStr_LC_28
    {
        // brute force
        public static int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0) return 0;
            if (haystack.Length == 0) return -1;

            int needleLen = needle.Length;
            char first = needle[0];

            for (int i = 0; i < haystack.Length; i++)
            {
                char current = haystack[i];
                if (current == first)
                {
                    string substring = "";
                    if (i <= haystack.Length - needleLen)
                    {
                        substring = haystack.Substring(i, needleLen);
                    }
                    if (substring.Length != 0)
                    {
                        var result = CompareStrings(substring, needle);
                        if (result) return i;
                    }
                }
            }
            return -1;
        }
        private static bool CompareStrings(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;
            else
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    if (!(s1[i] == s2[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        // 2 pointers
        public static int StrStr2(string haystack, string needle)
        {
            if (needle.Length == 0) return 0;
            if (needle.Length > haystack.Length) return -1;

            var needleIndex = 0;

            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle[needleIndex])
                {
                    needleIndex++;

                    if (needleIndex == needle.Length) return i - needleIndex + 1;
                }
                else
                {
                    i -= needleIndex;
                    needleIndex = 0;
                }
            }

            return -1;
        }
    }
}

