using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Arrays.Mix
{
    class Pairs_with_Specific_Difference___pramp
    {
        //arr = [0, -1, -2, 2, 1]
        //brute force with tuples
        public static int[,] FindPairsWithGivenDifference(int[] arr, int k)
        {
            var tempList = new List<(int, int)>();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    //k = 3 j = 3 i = 5
                    //i = k - j
                    //k = i - j
                    //j = i - k


                    //arr[j] == arr[i] - k
                    if (k == arr[i] - arr[j] || k == arr[j] - arr[i])
                    {
                        var tuple = (arr[i], arr[j]);
                        if (!tempList.Contains(tuple) || !tempList.Contains((tuple.Item2, tuple.Item1)))
                        {
                            tempList.Add(tuple);
                        }
                    }
                }
            }

            var result = new int[tempList.Count, 2];

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if (j == 0) result[i, j] = tempList[i].Item1;
                    else result[i, j] = tempList[i].Item2;
                }

            }
            return result;
        }

        //with dictionaries
        public static int FindPairsWithGivenDifference2(int[]nums, int k)
        {
            HashSet<int> hs = new HashSet<int>();
            HashSet<int> repeat = new HashSet<int>();
            if (k < 0)
                return 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (hs.Contains(nums[i]))
                    repeat.Add(nums[i]);
                else
                    hs.Add(nums[i]);
            }
            int count = 0;
            foreach (int val in hs)
            {
                if (hs.Contains(val + k))
                    count++;
            }
            if (k == 0)
            {
                return repeat.Count;
            }
            return count;

        }
    }
}
