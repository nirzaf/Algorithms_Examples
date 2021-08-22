using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomMedium
{
    public class Majority_Element_II_LC_229_M
    {
        public static IList<int> MajorityElement(int[] nums)
        {

            if (nums.Length == 1) return nums;
            if (nums.Length == 2)
            {
                if (nums[0] == nums[1]) return new List<int>() { nums[0] };
                else return nums;
            }

            var result = new List<int>();

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

                if (!result.Contains(nums[i]))
                {
                    if (dict[nums[i]] > (n / 3)) result.Add(nums[i]);
                }

            }


            return result;

        }

        //LINQ
        public IList<int> MajorityElement2(int[] nums)
        {
            List<int> res = new List<int>();
            if (nums?.Length == 0)
            {
                return res;
            }
            return nums.GroupBy(x => x).Select(x => new { x.Key, Count = x.Count() }).OrderByDescending(x => x.Count).Where(x => x.Count > nums.Length / 3).Select(y => y.Key).ToList();

        }

        //O(n) Boyer–Moore majority vote algorithm
        //good explanation: https://www.youtube.com/watch?v=gY-I8uQrCkk
        // the mjority element will be at Max 2 because it should be > floor(N/3) times and
        //if you mod(%) any num with 3 at max u can get 2 as remainder.
        public IList<int> MajorityElement3(int[] nums)
        {
            List<int> list = new List<int>();
            int limit = nums.Length / 3;
            int[] votes = new int[2];
            int[] candidates = new int[2];
            foreach (int n in nums)
            {
                if (n == candidates[0])
                {
                    votes[0]++;
                }
                else if (n == candidates[1])
                {
                    votes[1]++;
                }
                else if (votes[0] == 0)
                {
                    candidates[0] = n;
                    votes[0] = 1;
                }
                else if (votes[1] == 0)
                {
                    candidates[1] = n;
                    votes[1] = 1;
                }
                else
                {
                    votes[0]--;
                    votes[1]--;
                }
            }

            votes = new int[2];
            foreach (int n in nums)
            {
                if (n == candidates[0])
                    votes[0]++;
                else if (n == candidates[1])
                    votes[1]++;
            }

            if (votes[0] > limit)
                list.Add(candidates[0]);
            if (votes[1] > limit)
                list.Add(candidates[1]);

            return list;
        }

        public IList<int> MajorityElement4(int[] nums)
        {
            var n = nums.Length;

            var candidate1 = 0;
            var count1 = 0;

            var candidate2 = 0;
            var count2 = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                if (candidate1 == num)
                {
                    count1++;
                }
                else if (candidate2 == num)
                {
                    count2++;
                }
                else if (count1 == 0)
                {
                    candidate1 = num;
                    count1 = 1;
                }
                else if (count2 == 0)
                {
                    candidate2 = num;
                    count2 = 1;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }

            // check
            count1 = 0;
            count2 = 0;

            foreach (var num in nums)
            {
                if (candidate1 == num) count1++;
                else if (candidate2 == num) count2++;
            }

            var result = new List<int>();

            if (count1 > n / 3) result.Add(candidate1);
            if (count2 > n / 3) result.Add(candidate2);

            return result.ToArray();
        }

        //js
        //todo: understand
        /*
            var majorityElement = function(nums) {
                const ntimes = nums.length/3, hash = new Map();
                while(nums.length){
                    let val = nums.pop();
                    if(hash.has(val)){
                        hash.set(val, hash.get(val)+1);
                    } else
                        hash.set(val, 1);
                }
                for(let [key, value] of hash){
                    if(value > ntimes)
                        nums.push(key);
                }
    
                return nums;
            };
         
         
         
         */
    }
}
