using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class Contains_Duplicate_LC_217_E
    {
        public bool ContainsDuplicate(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1) return false;

            HashSet<int> visitedNumbers = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!visitedNumbers.Contains(nums[i]))
                {
                    visitedNumbers.Add(nums[i]);
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public bool ContainsDuplicate2(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1) return false;

            Array.Sort(nums);

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] == nums[i]) return true;
            }

            return false;
        }

        //JS
        /*
         var containsDuplicate = function(nums) {
            if (nums.length == 0 || nums.length == 1) return false;
            
            let visitedNumbers = new Set();

            for (let i = 0; i < nums.length; i++){
                if (!visitedNumbers.has(nums[i]))
                {
                    visitedNumbers.add(nums[i]);
                }
                else
                {
                    return true;
                }
            }
            return false;
        };

        XDDDDDDD
        var containsDuplicate = function(nums) {           
            let s = new Set(nums)
            return s.size != nums.length
        };
         
         
         
         
         
         
         
         
         */
    }
}
