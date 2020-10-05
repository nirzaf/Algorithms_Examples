using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns._2Pointers
{
    public class Remove_Duplicates_from_Sorted_Array_LC_26
    {
        //for reason i can't see it doesn't pass the tests
        public static int RemoveDuplicates(int[] nums)
        //return new HashSet<int>(nums).Count;
        {
            int left = 0, right = nums.Length - 1;
            int result = nums[right];
            int farLeft = nums[left];
            int farRight = nums[right];
            int index = 0;

            while(farLeft <= farRight)
            {
                nums[index] = farLeft;
                farLeft++;
                index++;
            }
            return result;
        }

        /// <summary>
        /// Each iteration we compare it to saved variable(ind i) with variable (ind j)
        /// if they are no the same we increment i and swap 
        /// if elemnts are in good order 1,2 -> i = 1 j = 1 so it swap 1 with 1 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int RemoveDuplicates2(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }
    }
    //[0, 0, 1, 1, 1, 2, 2, 3, 3, 4]
}
