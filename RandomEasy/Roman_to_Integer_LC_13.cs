using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.RandomEasy
{
    public class Roman_to_Integer_LC_13
    {
        public static int RomanToInt(string s)
        {
            if (s.Length == 0) return 0;

            var symbols = new Dictionary<string, int>()
            {
                {"I",1}, {"V",5}, {"X", 10}, {"L", 50}, {"C", 100}, {"D", 500} , {"M",1000},
                {"IV", 4}, {"IX", 9}, {"XL", 40}, {"XC", 90}, {"CD", 400}, {"CM", 900}
            };

            int result = 0;
            for (int i = 0; i < s.Length; i++)
                if ((s[i] == 'I' || s[i] == 'X' || s[i] == 'C') && i < s.Length - 1 && symbols.ContainsKey(s.Substring(i, 2)))
                    result += symbols[s.Substring(i++, 2)];
                else
                    result += symbols[s[i].ToString()];

            return result;
        }
    }
}
