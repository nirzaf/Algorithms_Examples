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

        // TODO: analyse this
        public int TotalFruit2(int[] tree)
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
