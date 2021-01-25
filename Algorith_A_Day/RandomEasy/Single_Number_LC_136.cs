using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.RandomEasy
{
    public class Single_Number_LC_136
    {
        //brute force 
        public static int SingleNumber(int[] nums)
        {
            if (nums == null) return -1;

            var dict = new Dictionary<int, int>();


            foreach (int number in nums)
            {
                if (!dict.ContainsKey(number))
                {
                    dict[number] = 1;
                }
                else
                {
                    dict[number]++;
                }
            }

            foreach (var kv in dict)
            {
                if (kv.Value == 1) return kv.Key;
            }

            return -1;
        }

        //JS
            //var singleNumber = function(nums) {
            //if (nums === null) return -1;

            //let dict = { };

            //for (let num of nums) {
            //    if (dict[num]) {
        		
            //        dict[num]++;
            //    }
            //    else {
            //        dict[num] = 1;
            //    }
            //}

            //    for (var kv in dict)
            //{
            //    if (dict[kv] === 1)
            //    {
            //        return kv;
            //    }
            //}
            //return -1;
            //};

// in place
public static int SingleNumber2(int[] nums)
        {
            if (nums == null) return -1;
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                if (i + 1 < nums.Length && nums[i] == nums[i + 1])
                {
                    i += 1;
                }
                else
                {
                    return nums[i];
                }

            }
            return -1;

            //public int SingleNumber(int[] nums)
            //{
            //    Array.Sort(nums);
            //    for (var i = 0; i < nums.Length - 1; i++)
            //    {
            //        if (nums[i] != nums[i + 1])
            //        {
            //            return nums[i];
            //        }
            //        else
            //        {
            //            i++;
            //        }
            //    }
            //    return nums[nums.Length - 1];
            //}
        }
        //JS
//        var singleNumber = function(nums) {
//          if (nums === null) return -1;
//            nums.sort();
//            for (var i = 0; i<nums.length; i++)
//            {
//                if (i + 1 < nums.length && nums[i] == nums[i + 1])
//                {
//                    i += 1;
//                }
//                else
//                {
//                    return nums[i];
//                }

//            }
//            return -1;
//          };
    }
}
