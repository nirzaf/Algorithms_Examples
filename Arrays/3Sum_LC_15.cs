using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Arrays
{
    public class ThreeSum_LC_15
    {
        //===========Find triplets in an array A, a + b = c where all elements are from the array
        //using sorting O(n log(n)) if we have one sum here we look for all the sums
        public static List<List<int>> FindTriplets(int[] arr)
        {
            var result = new List<List<int>>();
            var tempSumIndex = 0;
            while (tempSumIndex < arr.Length)
            {
                int leftIndex = 0;
                int rightIndex = arr.Length - 1;
                while (leftIndex < rightIndex)//arr is sorted
                {
                    if (arr[leftIndex] + arr[rightIndex] > arr[tempSumIndex])
                    {
                        rightIndex--;
                    }
                    else if (arr[leftIndex] + arr[rightIndex] < arr[tempSumIndex])
                    {
                        leftIndex++;
                    }
                    else
                    {
                        result.Add(new List<int> { arr[leftIndex], arr[rightIndex], arr[tempSumIndex] });
                        leftIndex++;
                    }
                }
                tempSumIndex++;
            }
            return result;
        }
        //using Dictionary O(n) if we have only one sum 

        public static List<List<int>> FindTriplestDictionary(int[] arr)
        {
            List<List<int>> result = new List<List<int>>();
            if (arr.Length < 0) return result;

            Dictionary<int, int> dict = new Dictionary<int, int>();
            int indexForSum = 0;
            int sum;

            while (indexForSum < arr.Length)
            {
                sum = arr[indexForSum];
                for (int i = 0; i < arr.Length; i++)
                {
                    if (dict.ContainsKey(sum - arr[i]))
                    {
                        var newList = new List<int>();
                        newList.Add(arr[indexForSum]);
                        newList.Add(arr[dict[sum - arr[i]]]);
                        newList.Add(arr[i]);
                        result.Add(newList);
                    }
                    dict.Add(arr[i], i);
                }
                dict.Clear();
                indexForSum++;
            }
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine($"{result[i][0]} + {result[i][1]} = {result[i][2]}");
            }
            return result;
        }
    }
}
