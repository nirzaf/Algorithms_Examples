using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorith_A_Day.RandomEasy
{
    public class Decompress_Run_Length_Encoded_List_LC_1313_E
    {
        public int[] DecompressRLElist(int[] nums)
        {
            if (nums == null || nums.Length == 0 || nums.Length % 2 != 0) return new int[] { };

            List<int> result = new List<int>();

            for (int i = 0; i <= nums.Length - 2; i += 2)
            {
                for (int j = 0; j < nums[i]; j++)
                {
                    result.Add(nums[i + 1]);
                }
            }
            return result.ToArray();
        }
    }


    //JS
    //var decompressRLElist = function(nums) {
    //return nums.reduce((a, n, i) => !(i % 2) ?[...a, ...Array(n).fill(nums[i + 1])] : a,[]); 
    //};
    //const decompressRLElist = ns =>
    //ns.reduce((acc, x, i) =>
    //   i % 2
    //       ? acc.concat(Array(ns[i - 1]).fill(x))
    //       : acc
    //    , []
    //)

    // PIEKNE ROZWIAZANIE
    //var decompressRLElist = function(nums) {
    //var result = [];
    //for (var i = 0; i<nums.length; i += 2) {
    //    var[freq, val] = [nums[i], nums[i + 1]];
    //    result.push(...returnGivenTimes(val, freq));
    //}
    //return result;
    //};

    //var returnGivenTimes = function(number, times) {
    //    return new Array(times).fill(number);
    //}
}
