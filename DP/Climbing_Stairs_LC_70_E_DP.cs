using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.DP
{
    // dp CAN be used to solve this problem but it is not necessary
    public class Climbing_Stairs_LC_70_E_DP

    {
        /// <summary>
        /// the idea here is we know result for 2 first steps 
        /// so each step we calculte next which we use in next iteration XDDD
        /// </summary>

        public int ClimbStairs(int n)
        {
            if (n < 0) return 0;
            if (n == 1 || n == 0) return 1;

            int[] result = new int[n + 1];

            result[0] = 1;
            result[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                result[i] = result[i - 1] + result[i - 2];
            }

            return result[n];

        }

        public int ClimbStairs2(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 2;

            var prePre = 1;
            var pre = 2;

            for (int i = 2; i < n; i++)
            {
                var cur = prePre + pre;
                prePre = pre;
                pre = cur;
            }

            return pre;
        }

        // recursion
        // todo: good recursion
        public int ClimbStairs3(int n)
        {
            Dictionary<int, int> mem = new Dictionary<int, int>();
            mem.Add(0, 0);
            mem.Add(1, 1);
            mem.Add(2, 2);
            return ClimbStairs(n, mem);
        }
        private int ClimbStairs(int n, Dictionary<int, int> mem)
        {
            if (mem.ContainsKey(n)) return mem[n];
            var result = ClimbStairs(n - 1, mem) + ClimbStairs(n - 2, mem);
            mem.Add(n, result);
            return result;
        }


        //JS
        //var climbStairs = function(n) {
        //       if (n< 0) return 0;

        //    result = [];

        //    result[0] = 1;
        //    result[1] = 1;

        //    for (i = 2; i <= n; i++)
        //    {
        //        result[i] = result[i - 1] + result[i - 2];
        //    }

        //    return result[n];
        //};
    }
}
