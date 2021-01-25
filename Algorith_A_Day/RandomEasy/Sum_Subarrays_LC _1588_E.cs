using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class Sum_Subarrays_LC__1588_E
    {
        public static int SumOddLengthSubarrays(int[] arr)
        {
            if (arr == null && arr.Length < 1) return 0;

            int result = 0;
            int len = arr.Length;

            for (int i = 1; i <= arr.Length; i += 2)
            {
                
                for (int j = 0; j <= arr.Length - i; j++)
                {
                    int temp = 0;
                    for (int k = j; k < i + j; k++)
                    {
                        temp += arr[k];
                    }
                    result += temp;
                }

                

            }
            return result;
        }

        public static int SumOddLengthSubarrays2(int[] arr)
        {
            int sum = 0;

            for (int i = 1; i <= arr.Length; i += 2)
                sum += GetSum(arr, i);

            return sum;
        }
        // [1,4,2,5,3]
        // first we add and then we do sliding window
        private static int GetSum(int[] arr, int len)
        {
            int totSum = 0;
            int sum = 0;
            int st = 0;
            int en = 0;

            // first we 1 4 2
            for (en = 0; en < len; en++)
                sum += arr[en];

            totSum += sum;

            // here we substract 1 and add 5 
            // here we substract 4 and add 3 
            while (en < arr.Length)
            {
                sum += arr[en];
                sum -= arr[st];
                totSum += sum;

                st++;
                en++;
            }

            return totSum;
        }

        // JS SAME
        //var sumOddLengthSubarrays = function(arr) {
        //let sum = 0;
        //// All possible odd numbers up to arr.length
        //for (let odd = 1; odd <= arr.length; odd += 2) {
        //    for (let i = 0; i + odd <= arr.length; i++) {
        //        let x = 0;
        //        for (let j = 0; j<odd; j++) x += arr[i + j]
        //      sum += x;
        //    }
        //    }

        //    return sum;
        //    };
    }
}
