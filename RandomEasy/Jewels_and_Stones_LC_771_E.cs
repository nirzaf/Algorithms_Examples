using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.RandomEasy
{
    public class Jewels_and_Stones_LC_771_E
    {
        public int NumJewelsInStones(string J, string S)
        {
            if (J.Length == 0 || S.Length == 0) return 0;

            int result = 0;

            foreach (char j in J)
            {
                foreach (char s in S)
                {
                    if (j == s) result++;
                }
            }
            return result;
        }
    }
}
