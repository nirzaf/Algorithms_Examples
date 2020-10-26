using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.BinarySearch
{
    public class Search_Insert_Position_LC_35
    {
        /// <summary>
        /// if the result is not found, then position will alway lie at start index,
        /// because considering the end=start is reached and at that index,
        /// the we will have numbder that is greater than target and because which our if
        /// condition will be executed at the last iteration.
        /// and hence end will be next smaller number than target and end is next larger number than target
        /// </summary>
        public static int SearchInsert(int[] nums, int target)
        {
            if (nums == null) return -1;

            int left = 0;
            int right = nums.Length - 1;


            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target) return mid;

                if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }
        //variation
        public static int SearchInsert2(int[] nums, int target)
        {
            if (nums == null) return -1;

            int left = 0;
            int right = nums.Length - 1;


            while (left + 1 < right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target) return mid;

                else if (nums[mid] > target)
                {
                    right = mid;
                }
                else
                {
                    //nums[mid] < target
                    left = mid;
                }
            }

            if(nums[right] < target)
            {
                return right + 1;
            }
            else if(nums[left] >= target)
            {
                return left;
            }
            else
            {
                //nums[start] < target < nums[end]
                return right;
            }
        }
        //https://stackoverflow.com/questions/4024429/what-does-a-single-vertical-bar-mean-in-javascript
        //Practical use for the operator
        //        ( 3|0 )                        === 3;
        //( 3.3|0 )                      === 3;
        //( 3.8|0 )                      === 3;
        //( -3.3|0 )                     === -3;
        //( -3.8|0 )                     === -3;
        //( "3"|0 )                      === 3;
        //( "3.8"|0 )                    === 3;
        //( "-3.8"|0 )                   === -3;
        //(NaN|0 )                      === 0;
        //(Infinity|0 )                 === 0;   
        //( -Infinity|0 )                === 0;     
        //( null|0 )                     === 0;          
        //((void 0)|0 )                 === 0;      
        //( []|0 )                       === 0;            
        //( [3]|0 )                      === 3;           
        //( [-3.8]|0 )                   === -3;       
        //( [" -3.8 "]|0 )               === -3;   
        //( [-3.8, 22]|0 )               === 0     
        //( {}|0 )                       === 0;            
        //( {'2':'3'}| 0 )                === 0;
        //((function(){ })| 0 )           === 0;
        //((function(){ return 3; })| 0 ) === 0;

        //JS
        //        var searchInsert = function(nums, target) {
        //        let start = 0;
        //        let end = nums.length - 1;
        //        let mid = 0
        //    while(start <= end) {
        //        mid = (start + end) / 2 | 0;
        //        if (nums[mid] === target) return mid;
        //        if (nums[mid] > target) {
        //            end = mid - 1; 
        //        } else {
        //            start = mid + 1;
        //        }
        //    }
        //    return start;
        //};
    }
}
