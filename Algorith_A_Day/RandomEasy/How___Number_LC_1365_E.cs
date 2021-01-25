using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class How___Number_LC_1365_E
    {
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            if (nums == null || nums.Length == 0) return new int[] { };

            var newArr = new int[nums.Length];
            nums.CopyTo(newArr, 0);

            Array.Sort(nums);
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]] = i;
                }
            }

            for (int j = 0; j < newArr.Length; j++)
            {
                int current = newArr[j];
                newArr[j] = dict[current];
            }

            return newArr;
        }

        public int[] SmallerNumbersThanCurrent2(int[] nums)
        {
            var tuples = nums.Select((x, i) => (x, i, c: 0)).OrderBy(t => t.x).ToArray();
            for (var i = 1; i < nums.Length; i++)
                tuples[i].c = tuples[i].x == tuples[i - 1].x ? tuples[i - 1].c : i;
            return tuples.OrderBy(t => t.i).Select(t => t.c).ToArray();
        }

        //JS =======
        //var smallerNumbersThanCurrent = function(nums) {
        //    let res = []
        //    let counter = 0
        //    for(i=0;i<nums.length;i++){
        //    for(j=0; j<nums.length;j++){
        //    if(i!=j && nums[i]>nums[j]){
        //    counter+=1
        //    }
        //    }
        //    res.push(counter)
        //    counter = 0
        //    }
        //    return res
        //};

        //var smallerNumbersThanCurrent = function(nums) {
        //    let res = [];
        //    nums.forEach((x, idx) => {
        //        let occurrence = 0;
        //        for (i = 0; i<nums.length; i++) {
        //            if (x == nums[i]) continue;
        //            if (x > nums[i]) occurrence++;
        //        }
        //        res[idx] = occurrence;
        //    });
        //    return res;
        //};

        //    var smallerNumbersThanCurrent = function(nums) {
        //        let sorted = nums.slice().sort((a, b) => a - b);
        //    let res = nums.map(x => sorted.indexOf(x));
        //    return res;
        //    };

    }
}
