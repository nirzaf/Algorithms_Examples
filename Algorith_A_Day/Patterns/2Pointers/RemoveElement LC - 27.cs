using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns._2Pointers
{
    public class RemoveElement_LC___27
    {
        public static int RemoveElement(int[] nums, int val)
        {
            //int j = 0;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if(nums[i] != val)
            //    {
            //        nums[j] = nums[i];
            //        j++;
            //    }
            //}
            //return j;


            //we swap val with last element and check again for val and decrement right pointer
            // we check again for val and decrement if they r equal
            int i = 0;
            int n = nums.Length;
            while (i < n)
            {
                if (nums[i] == val)
                {
                    nums[i] = nums[n - 1];
                    // reduce array size by one
                    n--;
                }
                else
                {
                    i++;
                }
            }
            return n;
        }
        
        //it shows right results but doesnt pass tests
        public static int RemoveElement2(int[] nums, int val)
        {
            int j = nums.Length - 1;
            int i = 0;
            if (nums.Length == 0) return -1;


            while (i < j)
            {
                while (nums[j] == val)
                {
                    j--;
                }
                if (nums[i] != val)
                {
                    i++;
                }
                else
                {
                    nums[i] = nums[j];
                    nums[j] = val;
                    j--;
                }
            }
            return nums.Length - (j + 1);
        }

    }
}
