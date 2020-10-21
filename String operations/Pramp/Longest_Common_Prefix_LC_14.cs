using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.String_operations.Pramp
{
    public class Longest_Common_Prefix_LC_14
    {
        // O(n^2)
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0 || strs == null) return "";

            string longest = "";
            string comparisonWord = strs[0];
            int comparisonIndex = 0;

            foreach (char letter in comparisonWord)
            {
                for (int i = 1; i < strs.Length; i++)
                {

                    var currentWord = strs[i];
                    char currentLetter = ' ';

                    if (comparisonIndex < currentWord.Length)
                    {
                        currentLetter = currentWord[comparisonIndex];
                    }
                    

                    if(letter != currentLetter || comparisonIndex > currentWord.Length)
                    {
                        return longest;
                    } 
                }
                comparisonIndex++;
                longest += letter;
            }
            return longest;
        }
        // O(n) w
        /// <summary>
        /// if there is no prefix it takes first word and cut one letter after another to ""
        /// for flower","flow","flight it takes flower as comparisonWord
        /// While(flow.indexof(flower)) returns -1 so flower.sunstring(0, 5) = flowe(5 letters)
        /// While(flow.indexof(flowe)) returns -1 so flowe.sunstring(0, 4) = flow(4 letters)
        /// While(flight.indexof(flow)) returns -1 so flow.sunstring(0, 3) = flo(3 letters)
        /// While(flight.indexof(flo)) returns -1 so flow.sunstring(0, 2) = fl(2 letters)
        /// While(flight.indexof(fl)) returns 0 prefix is fl
        /// </summary>

        public static string LongestCommonPrefix2(string[] strs)
        {
            if (strs.Length == 0 || strs == null) return "";

            string comparisonWord = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                while(strs[i].IndexOf(comparisonWord) != 0)
                {
                    comparisonWord = comparisonWord.Substring(0, comparisonWord.Length - 1);
                }
            }
            return comparisonWord;
        }

        //JS
        //var longestCommonPrefix = function(strs) {
        //if (strs.length === 0 || strs == null) return "";

        //let longest = "";
        //let comparisonWord = strs[0];
        //let comparisonIndex = 0;

        //for (let letter of comparisonWord)
        //{
        //    for (let i = 1; i<strs.length; i++)
        //    {
        //        let currentWord = strs[i];
        //let currentLetter = currentWord.charAt(comparisonIndex);

        //        if(letter !== currentLetter || comparisonIndex > currentWord.length)
        //        {
        //            return longest;
        //        }
        //    }
        //    comparisonIndex++;
        //    longest += letter;
        //    }
        //    return longest;
        //}
}
}

