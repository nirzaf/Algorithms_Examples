using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class Add_Binary_67_LC_E
    {
        // real BRUTE force xDDDD

        /// <summary>
        /// 
        /// </summary>

        public string AddBinary(string a, string b)
        {
            if (a.Length == 0) return b;
            if (b.Length == 0) return a;
            if (a.Length == 0 && b.Length == 0) return string.Empty;

            int aLen = a.Length - 1, bLen = b.Length - 1, carrier = 0;
            string result = string.Empty;

            while (aLen >= 0 && bLen >= 0)
            {
                if (carrier == 0)
                {
                    if (a[aLen] == '1' && b[bLen] == '1')
                    {
                        result = '0' + result;
                        carrier = 1;
                    }
                    else if (a[aLen] == '0' && b[bLen] == '0')
                        result = '0' + result;
                    else
                        result = '1' + result;
                }
                else
                {
                    if (a[aLen] == '1' && b[bLen] == '1')
                    {
                        result = '1' + result;
                        carrier = 1;
                    }
                    else if (a[aLen] == '0' && b[bLen] == '0')
                    {
                        result = '1' + result;
                        carrier = 0;
                    }
                    else
                    {
                        result = '0' + result;
                        carrier = 1;
                    }
                }

                aLen--;
                bLen--;
            }

            if (aLen >= 0)
            {
                if (carrier == 0)
                {
                    while (aLen >= 0)
                    {
                        result = a[aLen] + result;
                        aLen--;
                    }
                }
                else
                {
                    while (aLen >= 0)
                    {
                        if (a[aLen] == '1' && carrier == 1)
                        {
                            result = '0' + result;
                            carrier = 1;
                        }
                        else if (a[aLen] == '0' && carrier == 1)
                        {
                            result = '1' + result;
                            carrier = 0;
                        }
                        else
                            result = a[aLen] + result;

                        aLen--;
                    }
                }
            }

            if (bLen >= 0)
            {
                if (carrier == 0)
                {
                    while (bLen >= 0)
                    {
                        result = b[bLen] + result;
                        bLen--;
                    }
                }
                else
                {
                    while (bLen >= 0)
                    {
                        if (b[bLen] == '1' && carrier == 1)
                        {
                            result = '0' + result;
                            carrier = 1;
                        }
                        else if (b[bLen] == '0' && carrier == 1)
                        {
                            result = '1' + result;
                            carrier = 0;
                        }
                        else
                            result = b[bLen] + result;

                        bLen--;
                    }
                }
            }

            if (carrier == 1)
                result = '1' + result;

            return result;

        }

        // modulo and dividing by 2
        /// <summary>
        /// char - '0' returns number either way because '0' - '0' = 0 and '1' - '0' = 1
        /// carry is divided by 2 because after using it u need to be set to 0 for 1010 and 1011 
        /// for index 2, oneResult = 2(1+1+0) so carry 2/2 = 1(NOT FREAKING 0 lol) 2%2 = 0 so 0 is added
        /// for index 3, oneResult = 1(0+0+1!!!!) so carry 1/2 = 0 1%2 = 1 so 1 is added 
        /// for index 4, oneResult = 2(1+1+0) so carry 2/2 = 1 2%2 = 0 so 0 is added
        /// result is 1010 but carry = 1 so we add 1, result now 10101
        /// reverse doesnt change anything here.
        /// </summary>

        public string AddBinary2(string a, string b)
        {
            var result = new List<char>();

            var carry = 0;

            var aLen = a.Length;
            var bLen = b.Length;

            var aIndex = aLen - 1;
            var bIndex = bLen - 1;

            while (aIndex >= 0 || bIndex >= 0)
            {
                var numberA = aIndex >= 0 ? a[aIndex] - '0' : 0;
                var numberB = bIndex >= 0 ? b[bIndex] - '0' : 0;

                var oneResult = numberA + numberB + carry;
                carry = oneResult / 2;

                result.Add((char)(oneResult % 2 + '0'));

                aIndex--;
                bIndex--;
            }

            if (carry != 0)
            {
                result.Add((char)(carry + '0'));
            }

            result.Reverse();

            return new string(result.ToArray());
        }
    }
}
