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
    }
}

