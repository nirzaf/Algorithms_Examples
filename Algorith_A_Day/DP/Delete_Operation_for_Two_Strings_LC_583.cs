using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.DP
{
    /// <summary>
    /// Longest common subsequence problem
    /// </summary>
    public class Delete_Operation_for_Two_Strings_LC_583
    {
        //public static int MinDistance(string word1, string word2)
        //{

        //}



        // Pramp similar question
        public static int DeletionDistance(string str1, string str2)
        {
            int str1Len = str1.Length;
            int str2Len = str2.Length;

            var memo = new int[str1Len + 1, str2Len + 1];

            for (int i = 0; i <= str1Len; i++)
            {
                for (int j = 0; j <= str2Len; j++)
                {
                    if (i == 0)
                    {
                        memo[i, j] = j;
                    }
                    else if (j == 0)
                    {
                        memo[i, j] = i;
                    }
                    else if (str1[i - 1] == str2[j - 1])
                    {
                        memo[i, j] = memo[i - 1, j - 1];
                    }
                    else
                    {
                        memo[i, j] = 1 + Math.Min(memo[i - 1, j], memo[i, j - 1]);
                    }
                }
            }
            return memo[str1Len, str2Len];
        }
    }
}
