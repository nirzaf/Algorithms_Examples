using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.Patterns._2Pointers
{
    /// <summary>
    /// The easiest solution is to remove one element, check is it palindrome and insert the element back
    /// and then remove next one and check again etc. The TC of it is O(n^2)
    /// better option is to check until the chars are the same and then check if ranges of string is a palindrome where 
    /// ranges is [i+ 1...j] and [i...j -1] so for string abcXcpba we check string cXcp cutting ab and ba couse they met the conditions of palindrome
    /// </summary>
    public class Valid_Palindrome_II_LeetCode680
    {

        public static bool ValidPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            if (s.Length == 1 || s.Length == 2) return true;



            int rIndex = s.Length -1;
            int lIndex = 0;

            while (lIndex < rIndex)
            {
                if (s[rIndex] == s[lIndex])
                {
                    rIndex--;
                    lIndex++;
                }
                else
                {
                    return IsPalindromeRange(s, lIndex + 1, rIndex) ||
                           IsPalindromeRange(s, lIndex, rIndex - 1);
                }

                //else if (s[rIndex - 1] != s[lIndex])
                //{
                //    lIndex++;
                //    rIndex -= 2;

                //}
                //else if (s[rIndex] != s[lIndex + 1])
                //{
                //    rIndex--;
                //    lIndex += 2;
                //}
            }

            return true;
        }

        public static bool IsPalindrome(string s)
        {
            int i = 0;
            int j = s.Length - 1;

            while(i < j)
            {
                if(s[i] != s[j])
                {
                    return false;
                }
                i++;
                j--;
                // difrent way without 2 variables
                //if (s.ElementAt(i) != s.ElementAt(s.Length - 1 - i))
                //{
                //    return false;
                //}
            }
            return true;
        }

        public static bool IsPalindromeRange(string s, int left, int right)
        {
            while(left < right)
            {
                if(s[left] != s[right])
                {
                    return false;
                }
                left++;
                right--;

            }
            return true;
        }

        // brute force
        public static bool ValidPalindrome2(string s)
        {
            var sb = new StringBuilder(s);
            for (int i = 0; i < sb.Length; i++)
            {
                var c = sb[i];
                sb.Remove(i, 1);
                if (IsPalindrome(sb.ToString())) return true;
                sb.Insert(i, c);
            }

            return IsPalindrome(s);
        }
    }
}
