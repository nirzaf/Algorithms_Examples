using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithm_A_Day.Patterns.Sliding_Window
{
    public class Fruit_Into_Baskets_LC_904
    {
        public static int TotalFruit(int[] tree)
        {
            if (tree.Length == 0 || tree == null) return 0;

            int maxFruit = 1;
            var fruits = new Dictionary<int, int>();
            int j = 0;
            int i = 0;

            while(j < tree.Length)
            {
                if(fruits.Count <= 2)
                {
                    if (!fruits.ContainsKey(tree[j])) fruits.Add(tree[j], j);
                    else
                    {
                        fruits[tree[j]] = j;
                    }
                    j++;
                }

                if(fruits.Count > 2)
                {
                    int min = tree.Length - 1;
                    foreach (int val in fruits.Values)
                    {
                        min = Math.Min(min, val);
                    }

                    i = min + 1;
                    fruits.Remove(tree[min]);
                }

                maxFruit = Math.Max(maxFruit, j - i);
            }
            return maxFruit;
        }

        /// <summary>
        /// left is start of window and right is the end so[left.........right]
        /// both pointers are moving
        /// we keep right on the current number so NOT every iteration right increments
        /// for [3,3,3,1,2,1,1,2,3,3,4]
        /// till number 2 types looks like 3:3, 1:1 right = 4, left = 0 maxLen = 4
        /// types doesn't contain 2 and its Count is 2 so equals 2 so else executes
        /// then three times we decrement types[3] and remove it 
        /// state now : type 1:1 right = 4 left = 3
        /// if statement executes because types.Count < 2
        /// we add 2 so type 1:1 2:1 right = 5 left = 3
        /// if executes till 3, type 1:3 2:2, right = 8, left = 3,maxLen = 5
        /// else executes bc types.Count = 2 
        /// types[1]--, left++ so type 1:2 2:2, right = 8, left = 4,maxLen = 5
        /// types[2]--, left++ so type 1:2 2:1, right = 8, left = 5,maxLen = 5
        /// types[1]--, left++ so type 1:1 2:1, right = 8, left = 6,maxLen = 5
        /// types[1]--, left++ so type 2:1, right = 8, left = 7,maxLen = 5
        /// if executes bc types.Count = 1, type 3:1 2:1, right = 9, left = 7,maxLen = 5
        /// and so on IMPORTANT we set maxLen by substracting rigth - left not counting types dictionary
        /// </summary>
        public static int TotalFruit2(int[] tree)
        {
            int left = 0;
            int right = 0;
            int maxlen = 0;
            Dictionary<int, int> types = new Dictionary<int, int>();//contains the type and num of fruit;
            while (right < tree.Length && left <= right)
            {
                if (types.ContainsKey(tree[right]) || types.Count < 2)
                {
                    if (!types.ContainsKey(tree[right]))
                        types.Add(tree[right], 1);
                    else
                        types[tree[right]]++;

                    right++;
                    maxlen = Math.Max(maxlen, right - left);
                }
                else
                {
                    types[tree[left]]--;
                    if (types[tree[left]] == 0)
                        types.Remove(tree[left]);
                    left++;
                }
            }
            return maxlen;
        }



    }
}
