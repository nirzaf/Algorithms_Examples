using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Algorithm_A_Day.RandomEasy
{
    public class Integer_to_Roman_LC_12
    {
        private Numeral[] numerals = {
            new Numeral( "M",1000),
            new Numeral( "CM", 900),
            new Numeral( "D", 500),
            new Numeral( "CD", 400),
            new Numeral( "C", 100),
            new Numeral( "XC", 90),
            new Numeral( "L", 50),
            new Numeral( "XL", 40),
            new Numeral( "X", 10),
            new Numeral( "IX", 9),
            new Numeral( "V",5),
            new Numeral( "IV", 4)
            };

        /// <summary>
        /// brute force 
        /// division check how many of that string we need concatenate
        /// modulo "cut" processed number from the front 
        /// for 1240 
        /// 1240 / 1000  = 1 
        /// 1 * M 
        /// 1240 % 1000 = 240
        ///  etc
        /// </summary>

        public static string IntToRoman(int num)
        {
            StringBuilder result = new StringBuilder();
            int i = 0;

            i = num / 1000;
            for (; i > 0; i--)
                result.Append("M");

            num %= 1000;

            if (num / 900 == 1)
            {
                result.Append("CM");
                num %= 900;
            }

            if (num / 500 == 1)
            {
                result.Append("D");
                num %= 500;
            }

            if (num / 400 == 1)
            {
                result.Append("CD");
                num %= 400;
            }

            i = num / 100;
            for (; i > 0; i--)
                result.Append("C");

            num %= 100;

            if (num / 90 == 1)
            {
                result.Append("XC");
                num %= 90;
            }

            if (num / 50 == 1)
            {
                result.Append("L");
                num %= 50;
            }

            if (num / 40 == 1)
            {
                result.Append("XL");
                num %= 40;
            }

            i = num / 10;
            for (; i > 0; i--)
                result.Append("X");

            num %= 10;

            if (num / 9 == 1)
            {
                result.Append("IX");
                num %= 9;
            }

            if (num / 5 == 1)
            {
                result.Append("V");
                num %= 5;
            }

            if (num / 4 == 1)
            {
                result.Append("IV");
                num %= 4;
            }

            for (; num > 0; num--)
                result.Append("I");

            return result.ToString();
        }
        // with array/ class
        /// <summary>
        /// here we take advantage of oop using class
        /// we iterate over the numeral array from largest to smallest [ 1000 M -1 I ]
        /// each iteration we divide by numeral value to see how many symbols we need 
        /// then concatenate the number * symbol
        /// lastly do the modulo of numeral value 
        /// for 854
        /// 854 / 1000  = 0;
        /// 854 / 900  = 0;
        /// 854 / 500  = 1;
        /// result  = 1 * D
        /// 854 % 500 = 354
        /// 
        /// 354 / 400 = 0
        /// 354 / 100 = 3
        /// result += 3 * C
        /// 354 % 100 = 54
        /// 
        /// 54 / 90 = 0
        /// 54 / 50 = 1
        /// result += 1 * L
        /// 54 % 50 = 4
        /// 
        /// 4 / 40 = 0;
        /// 4 / 10 = 0;
        /// 4 / 9 = 0;
        /// 4 / 5 = 0;
        /// 4 / 4 = 1;
        /// result += 1 * IV
        /// DCCCLIV
        /// </summary>

        public string IntToRoman2(int num)
        {
            if (num <= 0) return "";

            string result = string.Empty;
            foreach(Numeral numeral in numerals)
            {
                int numberOfSymbols = num / numeral.Value;
                if (numberOfSymbols != 0)
                {
                    Enumerable.Range(0, numberOfSymbols)
                        .ToList().ForEach(arg => result += numeral.Symbol);
                   
                }
                num = num % numeral.Value;
            }
            return result;
        }

        internal class Numeral
        {
            public string Symbol { get; set; }
            public int Value { get; set; }

            public Numeral(string symbol, int value)
            {
                Symbol = symbol;
                Value = value;
            }
        }

        /// <summary>
        /// great easy solution with dictionary WOW
        /// idea is the same instead of doing modulo we just SUBSTRACT...
        /// we iterate over dictionary from largest to smallest
        /// for 846 
        /// 1000 <= 846 continue 
        /// 900 <= 846 continue 
        /// 500 <= 846 continue 
        /// 846 - 500 = 346
        /// result += D
        /// 400 <= 346 continue
        /// 100 <= 346 
        /// 346 -100
        /// 346 -100
        /// 346 -100 = 46
        /// result += 3 * CCC
        /// and so on...
        /// 
        /// </summary>

        public static string IntToRoman3(int num)
        {

            var dict = new Dictionary<int, string>() {
            {1000,"M"},{900,"CM"},{500,"D"},{400,"CD"},{100,"C"},
            {90,"XC"},{50,"L"},{40,"XL"},{10,"X"},
            {9,"IX"},{5,"V"},{4,"IV"},{1,"I"}
        };

            var sb = new StringBuilder();

            foreach (var pair in dict)
            {
                while (pair.Key <= num)
                {
                    sb.Append(pair.Value);
                    num = num - pair.Key;
                }
            }

            return sb.ToString();
        }
    }
}