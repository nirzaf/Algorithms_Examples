using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class Majority_Element_LC_169_E
    {
        public int MajorityElement(int[] nums)
        {
            if (nums.Length == 1 || nums.Length == 2) return nums[0];

            int n = nums.Length;

            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                }
                else
                {
                    dict[nums[i]] = 1;
                }

                if (dict[nums[i]] > (n / 2)) return nums[i];
            }

            return -1;
        }

        //LINQ
        public int MajorityElement2(int[] nums)
        {
            if (nums?.Length == 0)
            {
                return 0;
            }
            var maxCount = nums.GroupBy(x => x).Select(x => new { x.Key, Count = x.Count() }).OrderByDescending(x => x.Count).FirstOrDefault();

            return maxCount.Count > nums.Length / 2 ? maxCount.Key : 0;
        }
        //?? lol
        public int MajorityElement3(int[] nums) =>
            nums.OrderBy(x => x).ToArray()[nums.Length / 2];
        }

    /*
    This simple solution is an implementation of the "Baylor Moore" majority vote algrithm. The basic idea is to maintain a count for a given initial element.
    We increment that count if we encounter the same element and we decrement it we get a different element, when the count reaches zero,
    we update it to the newer element because this essentially means the the initial major element did not repeat itself sufficient times.

        Time Complexity: O(n)
        Space Complexity: O(1)

        Runtime: 104 ms, faster than 100.00% of C# online submissions for Majority Element.
        Memory Usage: 28.7 MB, less than 50.00% of C# online submissions for Majority Element.

        public int MajorityElement(int[] nums) {
            int major = nums[0];
            int count = 1;
            for(int i = 1; i < nums.Length; i++){
                if(count == 0){
                    major = nums[i];
                    count++;
                }else{
                    if(major == nums[i]){
                        count++;
                    }else{
                        count--;
                    }
                }
            }
            return major;
        }
     */

    /*
     O(1) Space:

            const majorityElement = (nums) => {
              let maj = '';
              let majCount = 0;

              for (const n of nums) {
                if (majCount === 0) {
                  maj = n;
                  majCount++;
                } else if (maj === n) majCount++;
                else majCount--;
              }
              return maj;
            };
            Hash Table:

            const majorityElement = (nums) => {
              const map = {};
              for (let n of nums) {
                map[n] = (map[n] || 0) + 1;
                if (map[n] > nums.length / 2) return n;
              }
            };
     Sort:
    var majorityElement = (nums) => nums.sort()[Math.floor(nums.length / 2)];
     */
}

