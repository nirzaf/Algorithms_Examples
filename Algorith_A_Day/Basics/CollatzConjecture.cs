using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Basics
{
    public class CollatzConjecture
    {
        public static int Collatz(int n)
        {
            if(n == 1) { return 0; }
            else if(n % 2 == 0)
            {
                return 1 + Collatz(n / 2);
            }
            else
            {
                return 1 + Collatz(3 * n  + 1);
            }
        }

        //c(5) 
        // 1 + c(15 + 1) c16
        // 1 + c(16 /2) c8
        // 1 + c(8 / 2) c4 
        // 1 + c(4 /2) c2
        // 1 + c(2 / 2) c1
        // c(1) = 0 base case

        public static int CollatzIterativly(int n)
        {
            if (n == 1) { return 0; }
            int counter = 0;
            while(n > 1)
            {
                if(n % 2 == 0)
                {
                    counter++;
                    n = n / 2;
                }
                else
                {
                    counter++;
                    n = n * 3 + 1;
                }
            }
            return counter;
        }
    }
}
