using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns._2Pointers
{
    public class _3Sum_Closest_LC_16
    {
        public static int ThreeSumClosest(int[] nums, int target)
        {
            int closestGlobal = int.MaxValue;
            int globalSum = 0;

            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                int left = i + 1; 
                int right = nums.Length - 1;

                while (left < right)
                {                   
                    int currentSum = nums[i] + nums[left] + nums[right];
                    var closestLocal = Math.Abs(currentSum - target);

                    if (currentSum == target) return target;
                    else if (currentSum > target)
                    {
                        right--;
                    }
                    else
                    {
                        left++;
                    }

                    if(closestGlobal > closestLocal)
                    {
                        closestGlobal = closestLocal;
                        globalSum = currentSum;
                    }
                }
            }
            
            return globalSum;
        }
    }
}
