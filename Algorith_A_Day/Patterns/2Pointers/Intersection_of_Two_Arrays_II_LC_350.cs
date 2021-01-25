using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns._2Pointers
{
    public class Intersection_of_Two_Arrays_II_LC_350
    {
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            var result = new List<int>();
            Array.Sort(nums1);
            Array.Sort(nums2);

            int p1 = 0, p2 = 0;

            while (p1 < nums1.Length && p2 < nums2.Length)
            {
                if (nums1[p1] < nums2[p2])
                {
                    p1++;
                }
                else if (nums1[p1] > nums2[p2])
                {
                    p2++;
                }
                else
                {
                    result.Add(nums1[p1]);
                    p1++;
                    p2++;
                }

            }
            return result.ToArray();
        }

        // with dictionary 
        public static int[] Intersect2(int[] nums1, int[] nums2)
        {
            var numAndCount1 = new Dictionary<int, int>();

            foreach (var num in nums1)
            {
                if (!numAndCount1.ContainsKey(num)) numAndCount1[num] = 0;

                numAndCount1[num]++;
            }

            var result = new List<int>();

            foreach (var num in nums2)
            {
                if (numAndCount1.ContainsKey(num) && numAndCount1[num] > 0)
                {
                    result.Add(num);

                    numAndCount1[num]--;
                }
            }

            return result.ToArray();
        }
    }
}
