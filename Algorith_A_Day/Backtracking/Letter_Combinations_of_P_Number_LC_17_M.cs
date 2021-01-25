using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Backtracking
{
    public class Letter_Combinations_of_P_Number_LC_17_M
    {

        /// <summary>
        /// See the Backtracking file
        /// </summary>

        public static IList<string> LetterCombinations(string digits)
        {
            var result = new List<string>();
            if (digits.Length == 0 || digits == null) return result;

            var mapping = new string[]
            {
                "0",
                "1",
                "abc",
                "def",
                "ghi",
                "jkl",
                "mno",
                "pqrs",
                "tuv",
                "wxyz",
            };

            LetterCombinationsRecursive(result, digits, "", 0, mapping);

            return result;

        }

        private static void LetterCombinationsRecursive(List<string> result, string digits,
                                                    string current, int index, string[] mapping)
        {
            //base case
            if(index == digits.Length)
            {
                result.Add(current);
                return;
            }
            // -'0' makes it integer
            // for digits = "23" letters = abc or def 
            string letters = mapping[digits[index] - '0'];

            for (int i = 0; i < letters.Length; i++)
            {
                LetterCombinationsRecursive(result, digits, current + letters[i],
                    index + 1, mapping);
            }
        }
    }
}
