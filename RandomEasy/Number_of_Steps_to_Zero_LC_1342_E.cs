using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{

    // check if number is an int https://stackoverflow.com/questions/2751593/how-to-determine-if-a-decimal-double-is-an-integer
    public class Number_of_Steps_to_Zero_LC_1342_E
    {
        public int NumberOfSteps(int num)
        {
            var x = num % 1 == 0;
            if (num <= 0 || !(num % 1 == 0)) return 0;

            int steps = 0;

            while (num > 0)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                }
                else
                {
                    num -= 1;
                }
                steps++;
            }
            return steps;
        }
    }
}
