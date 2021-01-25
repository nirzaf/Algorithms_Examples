using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.RandomEasy
{
    public class Plus_One_66_LC_E
    {
        public static int[] PlusOne(int[] digits)
        {
            if (digits[0] == 0 && digits.Length == 1) return new int[] { 1 };
            int len = digits.Length - 1;

            if (digits[len] != 9)
            {
                digits[len]++;
                return digits;
            }
            // last digit is 9
            else
            {
                var current = digits[len];
                while (current >= 9)
                {
                    // cases 999, 99, 9 etc.
                    if (len == 0 && current >= 9)
                    {
                        string number = "1" + (string.Concat(Enumerable.Repeat("0", 1 * digits.Length)));
                        return number.Select(x => (int)char.GetNumericValue(x)).ToArray();
                    }
                    digits[len] = 0;
                    digits[--len]++;
                    current = digits[len];
                    // last was 9 but next to it was less than 9
                    if (current < 10)
                    {
                        return digits;
                    }
                }
            }
            return digits;
        }

        // similar to above but smarter 
        // taking advantage of array element default value 0

        public static int[] PlusOne2(int[] digits)
        {
            int len = digits.Length;
            int i = len - 1;
            while (i >= 0)
            {
                // digit is less than 9 
                if (digits[i] < 9)
                {
                    digits[i] += 1;
                    break;
                }
                // digit equals 9
                else
                {
                    digits[i] = 0;
                }
                i--;
            }
            // not all digits were 9
            if (i >= 0)
            {
                return digits;
            }
            int[] arr = new int[len + 1];
            arr[0] = 1;
            return arr;
        }

        public static int[] PlusOne3(int[] digits)
        {
            var last = digits.Length - 1;
            while (last >= 0 && digits[last] == 9)
            {
                digits[last] = 0;
                last--;
            }
            if (last < 0)
            {
                Array.Resize(ref digits, digits.Length + 1);
                last = 0;
            }
            digits[last]++;
            return digits;
        }
        // other approach 
        public static int[] PlusOne4(int[] digits)
        {
            var result = new List<int>();

            var carry = 0;

            var n = digits.Length;

            for (int i = n - 1; i >= 0; i--)
            {
                var oneResult = digits[i] + carry;
                if (i == n - 1)
                {
                    oneResult += 1;
                }

                carry = oneResult / 10;
                result.Add(oneResult % 10);
            }

            if (carry != 0)
            {
                result.Add(carry);
            }

            result.Reverse();

            return result.ToArray();
        }


    }
}
