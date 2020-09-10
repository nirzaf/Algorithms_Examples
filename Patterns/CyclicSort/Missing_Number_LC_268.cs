using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.CyclicSort
{
    public class Missing_Number_LC_268
    {
        public static int MissingNumber(int[] nums)
        {
            
            for (int i = 0; i < nums.Length; i++)
            {
                int current = nums[i]; //i =2 , current = 3;
                if (current == nums.Length) continue;
                if(current != i)
                {
                    int temp = nums[current]; //4
                    nums[current] = current;
                    nums[i] = temp;
                    i--;
                }
            }
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != j) return j;
            }
            return nums.Length;
        }
    }
}
