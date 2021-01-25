using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.RecursiveToDeal
{

    //todo: recursion to learn 
    public class Int_To_Roman_LC_12_Recursion
    {
        public class Solution
        {
            public string IntToRoman(int num)
            {
                return getRoman(num);
            }

            private string getRoman(int num)
            {
                if (num >= 1000)
                {
                    return $"{getRomanStr(num / 1000, 'M')}{getRoman(num % 1000)}";
                }
                else if (num >= 500)
                {
                    string s = "D";
                    if (num >= 900)
                    {
                        s = "CM";
                        num = num - 400;
                    }
                    return $"{s}{getRoman(num - 500)}";
                }
                else if (num >= 100)
                {
                    string s = num >= 400 ? "CD" : getRomanStr(num / 100, 'C');
                    return $"{s}{getRoman(num % 100)}";
                }
                else if (num >= 50)
                {
                    string s = "L";
                    if (num >= 90)
                    {
                        s = "XC";
                        num = num - 40;
                    }
                    return $"{s}{getRoman(num - 50)}";
                }
                else if (num >= 10)
                {
                    string s = num >= 40 ? "XL" : getRomanStr(num / 10, 'X');
                    return $"{s}{getRoman(num % 10)}";
                }
                else if (num >= 5)
                {
                    string s = "V";
                    if (num >= 9)
                    {
                        s = "IX";
                        num = num - 4;
                    }
                    return $"{s}{getRoman(num - 5)}";
                }
                else
                {
                    string s = num >= 4 ? "IV" : getRomanStr(num, 'I');
                    return s;
                }
            }

            private string getRomanStr(int num, char r)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < num; i++) sb.Append(r);
                return sb.ToString();
            }
        }
    }
}
