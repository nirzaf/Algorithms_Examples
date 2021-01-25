using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.Arrays
{
    public class Kids_With_Candies_LC_1431_E
    {
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            List<bool> result = new List<bool>();
            if (candies.Length == 0 || candies == null || extraCandies < 0) return result;

            int maxVal = candies.Max();

            foreach (int can in candies)
            {
                if (can + extraCandies >= maxVal)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
            }
            return result;
        }

        public IList<bool> KidsWithCandies2(int[] candies, int extraCandies)
        {
            var max = candies.Max();
            return candies.Select(c => c + extraCandies >= max).ToList();
        }

    }
}
