using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.RandomEasy
{
    public class Check_Equivalent_1662_LC_E
    {
        // simple brute force O(n)
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            string w1 = string.Empty;
            string w2 = string.Empty;
            foreach (string item in word1)
            {
                w1 += item;
            }

            foreach (string item in word2)
            {
                w2 += item;
            }

            return w1 == w2;
        }

        public bool ArrayStringsAreEqual2(string[] word1, string[] word2)
        {
            return string.Join("", word1) == string.Join("", word2);
        }
    }
}
