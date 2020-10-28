using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Basics
{
    class Factorial
    {
        public static int NtFactorial(int nummber)
        {
            if (nummber == 0) return 1;
            if (nummber < 0) throw new ArgumentException("Negative nummber are not allowed!");
            
            int facNumber = 1;

            for (int i = 1; i <= nummber; i++)
            {
                facNumber *= i;
            }
            return facNumber;
        }
        
        public static int FactorialRecursive(int nummber)
        {
            if (nummber == 0) return 1; //THIS IS BASE CASE
            if (nummber < 0) throw new ArgumentException("Negative nummber are not allowed!");
            else
            {
                return nummber * FactorialRecursive(nummber - 1);
            }
           
        }


        //JS
        //function fac(a)
        //{
        //    if (a == 0) return 1;
        //    else
        //    {
        //        return a * fac(a - 1);
        //    }
        //}

        //console.log(fac(3));

        // return 1;
        // return 1 * fac(0); -> 1 * 1
        // retrurn 2 * fac(1); -> 2 * 1
        // return 3 * fac(2); -> 3 * 2
        //5 1 * 2 * 3 * 4 * 5
    }
}

