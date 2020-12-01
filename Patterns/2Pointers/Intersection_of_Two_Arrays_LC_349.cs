using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.Patterns._2Pointers
{
    /// <summary>
    /// LeetCode - 349. Intersection of Two Arrays
    /// 1.We sort both 2.We create 2 pointers: one for each input arrays 
    /// 3. run while loop for len of arrays
    /// 4.increamnt index depends on which element of array is bigger/smaller/the same( -> add to hashset)
    /// while loop conditions check if index are in range
    /// we compere elements on both arr if el is smaller we increase containing array index 
    /// </summary>
    public class Intersection_of_Two_Arrays_LC_349
    {
        public static int[] IntersectionMethod(int[] nums1, int[] nums2)
        {
            var hash = new HashSet<int>();

            Array.Sort(nums1);
            Array.Sort(nums2);
            int i = 0, j = 0;

            while(i < nums1.Length && j < nums2.Length)
            {
                if(nums1[i] < nums2[j])
                {
                    i++;
                }else if(nums1[i] > nums2[j])
                {
                    j++;
                }
                else
                {
                    hash.Add(nums1[i]);
                    i++;
                    j++;
                }
            }

            int[] res = new int[hash.Count];
            int k = 0;
            foreach (int num in hash)
            {
                res[k++] = num;
            }

            return res;

            //this works as well XDDDD
            //var ans = new HashSet<int>(nums1);
            //ans.IntersectWith(nums2);

            //return ans.ToArray();
        }

        public int[] Intersection2(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums1.Length == 0 || nums2 == null || nums2.Length == 0)
                return new int[] { };

            int i = 0,
                j = 0;
            List<int> res = new List<int>();

            Array.Sort(nums1);
            Array.Sort(nums2);

            while (i < nums1.Length && j < nums2.Length)
            {
                while (i < nums1.Length - 1 && nums1[i] == nums1[i + 1])
                    i++;

                while (j < nums2.Length - 1 && nums2[j] == nums2[j + 1])
                    j++;

                if (nums1[i] == nums2[j])
                {
                    res.Add(nums1[i]);

                    i++;
                    j++;
                }
                else if (nums1[i] < nums2[j])
                    i++;
                else
                    j++;
            }

            return res.ToArray();
        }
    }
}
