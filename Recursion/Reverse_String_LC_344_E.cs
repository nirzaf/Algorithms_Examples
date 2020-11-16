using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Recursion
{
    public class Reverse_String_LC_344_E
    {
        // recursive
        public static void ReverseString(char[] s)
        {
            if (s == null || s.Length == 0) return;

            helper(s, 0, s.Length - 1);
        }

        private static void helper(char[] s, int start, int end)
        {
            if (start > end) return;
            var temp = s[start];
            s[start] = s[end];
            s[end] = temp;
            helper(s, start + 1, end - 1);
        }

        // same but interatively
        public void ReverseString2(char[] s)
        {
            var n = s.Length;
            var left = 0;
            var right = n - 1;

            while (left < right)
            {
                var temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }
        }
    }
}
