using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Arrays
{
    public class Merge_Sorted_Array_88
    {
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var len = m + n;
            var i1 = m - 1;
            var i2 = n - 1;
            for (int i = len - 1; i >= 0; i--)
            {
                if (i1 >= 0 && i2 >= 0)
                {
                    if (nums1[i1] > nums2[i2])
                    {
                        nums1[i] = nums1[i1];
                        i1--;
                    }
                    else
                    {
                        nums1[i] = nums2[i2];
                        i2--;
                    }
                }
                else if (i1 >= 0)
                {
                    nums1[i] = nums1[i1];
                    i1--;
                }
                else
                {
                    nums1[i] = nums2[i2];
                    i2--;
                }
            }
        }

        public static void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            int l1 = m - 1;
            int l2 = n - 1;
            int l3 = m + n - 1;

            while (l2 >= 0)
            {
                if (l1 < 0 || nums2[l2] >= nums1[l1])
                {
                    nums1[l3] = nums2[l2];
                    l2--;
                }
                else
                {
                    nums1[l3] = nums1[l1];
                    l1--;
                }
                l3--;

            }
        }
    }
}
