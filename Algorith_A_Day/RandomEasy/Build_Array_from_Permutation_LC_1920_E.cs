using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class Build_Array_from_Permutation_LC_1920_E
    {
        public int[] BuildArray(int[] nums)
        {
            if (nums == null) return Array.Empty<int>();

            int[] result = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                int current = nums[i];
                result[i] = nums[current];
            }

            return result;
        }

        //using bit-shifting....
        //In order to optimize the solution somewhat, and to meet the Follow-Up requirement for O(1) space complexity,
        //we can rely on bit-shifting, something which is possible due to the low values in nums.
        //https://leetcode.com/problems/build-array-from-permutation/discuss/1315480/Java-or-O(1)-Space-O(n)-Time
        public int[] BuildArray2(int[] nums)
        {
            int mask = 1023; // Decimal value of the binary number '1111111111'
            for (int i = 0; i < nums.Length; i++)
                nums[i] |= (nums[nums[i]] & mask) << 10;
            for (int i = 0; i < nums.Length; i++)
                nums[i] = nums[i] >> 10;
            return nums;
        }


        /*
        const buildArray=nums=>{
           return nums.reduce((total,item,index)=>{
              total.push(nums[nums[index]])
              return total
           },[])
        }

        */

        /*
        const buildArray=nums=>{
           let result=nums.map((item,index)=>nums[nums[index]])
           return result
        }

        */

        /*
        const buildArray=nums=>{
           let result=[]
           nums.forEach((item,index)=>{
              result[index]=nums[nums[index]]
           })
           return result
        }
        */
    }
}
