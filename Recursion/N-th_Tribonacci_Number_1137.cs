using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Recursion
{
    /// <summary>
    //          x   y   z
    //    T_3 = 0 + 1 + 1 = 2
    //    T_4 = 1 + 1 + 2 = 4
    //    T_5 = 1 + 2 + 4 = 7
    //    T_6 = 2 + 4 + 7 = 13
    //    T_7 = 4 + 7 + 13 = 24
    /// </summary>
    public class N_th_Tribonacci_Number_1137
    {
        // iteratively
        public static int Tribonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1 || n == 2) return 1;

            int x = 0, y = 1, z = 1;
            int result = 0;

            for (int i = 3; i <= n; i++)
            {
                result = x + y + z;
                x = y;
                y = z;
                z = result;
            }

            return result;
        }
        //reciursively
        public static int Tribonacci2(int n)
        {
            if (n == 0) return 0;
            else if (n == 1 || n == 2) return 1;
            else
            {
                return Tribonacci2(n - 1) + Tribonacci2(n - 2) + Tribonacci(n -3);

            }
        }
    }   

    
}
