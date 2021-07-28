using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class Create_Order_1389_LC_E
    {
        //unfinished wypociny 
        //public static int[] CreateTargetArray(int[] nums, int[] index)
        //{
        //    if (nums.Length != index.Length) return new int[] { };

        //    int[] target = new int[nums.Length];

        //    for (int j = 0; j < target.Length; j++)
        //    {
        //        target[j] = -1;
        //    }

        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (target[index[i]] != -1)
        //        {
        //            int[] temp = new int[nums.Length];
        //            for (int k = index[i] + 1; k < target.Length; k++)
        //            {
        //                temp[k] = target[k - 1];
        //            }
        //            temp[index[i]] = nums[i];
        //            target = temp;
        //        }
        //        else
        //        {
        //            target[index[i]] = nums[i];
        //        }

        //    }

        //    return target;

        //}

        public static int[] CreateTargetArray(int[] nums, int[] index)
        {
            List<int> res = new List<int>();
            for (int i = 0; i < index.Length; i++)
            {
                res.Insert(index[i], nums[i]);
            }
            return res.ToArray();
        }

        public static int[] CreateTargetArray2(int[] nums, int[] index)
        {

            var _target = Enumerable.Repeat(101, nums.Length).ToArray();


            for (var i = 0; i < nums.Length; i++)
            {
                var _index = index[i];

                var val = nums[i];

                if (_target[_index] == 101)
                    _target[_index] = val;
                else
                {
                    var _tmp = _target[_index];

                    _target[_index] = val;

                    //TODO: understand
                    for (int start = _index + 1; start < _target.Length; start++)
                    {
                        var _t2 = _target[start];

                        _target[start] = _tmp;

                        _tmp = _t2;
                    }
                }
            }
            return _target;

        }

        /*
          splice(start, deleteCount, item1)
          splice(start, deleteCount, item1, item2, itemN)
         var createTargetArray = function(nums, index) {
            const target = []
            for (let i=0;i<nums.length;i++){
                target.splice(index[i],0, nums[i]);//at index[i], delete 0 element and insert element nums[i]
            }
            return target
        };
         
         
         
         */
    }
}
