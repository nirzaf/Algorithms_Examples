using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.Patterns.K_thLargestElement
{
    public class Kth_Largest_Element
    {
        // naive solution n log(n) as it uses .net sort algo (insertion if n < 16 , or heap or quick sort)
        public int FindKthLargest(int[] nums, int k)
        {
            Array.Sort(nums);
            return nums[nums.Length - k];
        }
        /// <summary>
        /// Goal here is to leave always k largest items in dictionary
        /// every iteration:
        /// -we add items to dictionary Key:number,Value: quantity
        /// - check if dictionary size is not bigger than k if yes :
        /// we take first element in dictionary and remove(or decrement) it
        /// </summary>
        /// <returns></returns>
        //min heap solution with sorted dictionary
        public int FindKthLargest2(int[] nums, int k)
        {
            SortedDictionary<int, int> minHeap = new SortedDictionary<int, int>();
            int heapSize = 0;

            foreach (int num in nums)
            {
                if (minHeap.ContainsKey(num))
                {
                    minHeap[num]++;
                }
                else
                {
                    minHeap.Add(num, 1);
                }
                heapSize++;

                if (heapSize > k)
                {
                    var min = minHeap.First();
                    if (min.Value == 1) minHeap.Remove(min.Key);
                    else
                    {
                        minHeap[min.Key]--;
                    }
                    heapSize--;
                }
            }
            return minHeap.First().Key;
        }
        // TODO: merge when we revision of merge sort
        //public int FindKthLargest3(int[] nums, int k)
        //{
            
        //}
    }
}
