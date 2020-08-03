using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.String_operations
{
    public class Longest_Sub_String
    {
        public static string GetLongestSubString(string input)
        {
            int maxLen = 0;
            int currentLen = 1;
            string result = input[0].ToString();
            char currentChar = input[0];

            for (int i = 1; i < input.Length; i++)
            {
                if(input[i] == currentChar)
                {
                    currentLen++;
                    if(maxLen < currentLen)
                    {
                        maxLen = currentLen;
                        result = new string(currentChar, maxLen);
                        continue;
                    }
                    if(result[0] == input[i])
                    {
                        result += input[i];
                    }
                }
                else
                {
                    currentLen = 1;
                    currentChar = input[i];
                }
            }
            if (result == null) return input[0].ToString();

            return result;
        }
    }
}
