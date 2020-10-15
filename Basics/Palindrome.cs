using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Basics
{
    class Palindrome
    {
        /// <summary>
        /// Determines if a single word is a palindrome.
        /// </summary>
        /// <param name="word">a word</param>
        /// <returns>true if palindrome, otherwise false</returns>
        static bool IsWordPalindrome(string word)
        {
            if (word == null)
                throw new ArgumentNullException(nameof(word));

            if (word.Length < 2)
                return true;

            return IsPalidrome(0, word.Length - 1);

            bool IsPalidrome(int lo, int hi)
            {
                if (lo >= hi)
                    return true;

                if (char.ToUpperInvariant(word[lo]) !=
                    char.ToUpperInvariant(word[hi]))
                    return false;

                return IsPalidrome(lo + 1, hi - 1);
            }
        }
        
    }
}
