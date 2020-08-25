using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns._2Pointers
{
    public class Valid_Palindrome_II_LeetCode680
    {
        public bool ValidPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            if (s.Length == 1 || s.Length == 2) return true;



            int rIndex = s.Length -1;
            int lIndex = 0;
            int counter = 0;
            int removed = 0;

            while(rIndex < lIndex)
            {
                if(s[rIndex] == s[lIndex])
                {
                    rIndex--;
                    lIndex++;
                    counter += 2;
                }
                if (s[rIndex - 1] == s[lIndex])
                {
                    rIndex--;
                    lIndex += 2;
                    removed++;
                }
                else if (s[rIndex] == s[lIndex + 1])
                {
                    rIndex -= 2;
                    lIndex++;
                    removed++;
                }
                if (removed > 1) return false;
            }

            if (s.Length - counter == 1 || s.Length - counter == 0)
            {
                return true;
            }
            return false;
        }
    }
}
