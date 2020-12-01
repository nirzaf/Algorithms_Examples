using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.Multidimensional_Arrays
{
    public class Kth_Smallest_Element_in__Sorted_Matrix_LC_378_M
    {
        

        //brute force
        public int KthSmallest1(int[][] matrix, int k)
        {
            var list = new List<int>();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    list.Add(matrix[i][j]);
                }
            }

            return list.OrderBy(e => e).Skip(k - 1).First();
        }


        // binary search
        public static int KthSmallest2(int[][] matrix, int k)
        {
            List<int> sorted = new List<int>();

            int row = matrix.Length;
            int col = matrix[0].Length;
            if (row == 0 && col == 0) return 0;

            if (row == 1) return matrix[0][k - 1];

            // we initialize the list with the first array, it's sorted already 
            for (int c = 0; c < col; c++)
            {
                sorted.Add(matrix[0][c]);
            }

            // now we can add every other value to the sorted list 
            for (int r = 1; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    placeValue(sorted, matrix[r][c]);
                }
            }

            return sorted[k - 1];
        }

        private static void placeValue(List<int> sorted, int val)
        {

            helper(sorted, val, 0, sorted.Count);

        }

        // a binary search sort
        private static void helper(List<int> sorted, int val, int left, int right)
        {
            if (left > right)
            {
                sorted.Add(val);
            }

            // check the middle point 
            int mid = left + (right - left) / 2;

            // if the middle point is equal, just insert to the middle point 
            if (sorted[mid] == val)
            {
                sorted.Insert(mid, val);
            }
            // if the middle point is greater, it means the value should be in the lower part 
            else if (sorted[mid] > val)
            {

                // if the mid point is at the beginning, add it now 
                if (mid == 0)
                {
                    sorted.Insert(0, val);
                }
                // however, if the previous point is lesser, that means we find the value's position 
                else if (sorted[mid - 1] < val)
                {
                    sorted.Insert(mid, val);
                }
                // otherwise, move to left of middle point and try again 
                else
                {
                    helper(sorted, val, left, mid - 1);
                }
            }
            // if the mid point is lesser, the value should be on the upper point 
            else
            {
                // if the mid point is the end already, we just append to the end 
                if (mid == right - 1)
                {
                    sorted.Insert(right, val);
                }
                // if the right of the mid point is greater, then it means we find the value's position
                else if (sorted[mid + 1] >= val)
                {
                    sorted.Insert(mid + 1, val);
                }
                // otherwise we move to right of mid point and try again 
                else
                {
                    helper(sorted, val, mid + 1, right);
                }
            }
        }

        // heap
        public static int KthSmallest3(int[][] matrix, int k)
        {
            int row = matrix.Length;
            int col = matrix[0].Length;
            SortedList<int, Tuple<int, int>> queue = new SortedList<int, Tuple<int, int>>(new DuplicateKeyComparer<int>());
            queue.Add(matrix[0][0], new Tuple<int, int>(0, 0));
            bool[,] visited = new bool[row, col];
            while (queue.Count > 0)
            {
                Tuple<int, int> node = queue.ElementAt(0).Value;
                if (--k == 0)
                    return queue.ElementAt(0).Key;
                queue.RemoveAt(0);
                if (node.Item1 + 1 < row && !visited[node.Item1 + 1, node.Item2])
                {
                    queue.Add(matrix[node.Item1 + 1][node.Item2], new Tuple<int, int>(node.Item1 + 1, node.Item2));
                    visited[node.Item1 + 1, node.Item2] = true;
                }
                if (node.Item2 + 1 < col && !visited[node.Item1, node.Item2 + 1])
                {
                    queue.Add(matrix[node.Item1][node.Item2 + 1], new Tuple<int, int>(node.Item1, node.Item2 + 1));
                    visited[node.Item1, node.Item2 + 1] = true;
                }
            }
            return -1;
        }

        public static int KthSmallest31(int[][] matrix, int k)
        {
            int result = 0;

            var rows = matrix.Length;
            var columns = matrix[0].Length;

            var s = new SortedList<int, Tuple<int, int>>(new DuplicateKeyComparer<int>());

            for (int col = 0; col < columns; col++)
            {
                s.Add(matrix[col][0], new Tuple<int, int>(col, 0));
            }

            while (k > 0)
            {
                result = s.First().Key;
                int x = s.First().Value.Item1;
                var y = s.First().Value.Item2;

                s.RemoveAt(0);

                if (y < columns - 1)
                {   // go to next column 
                    s.Add(matrix[x][y + 1], new Tuple<int, int>(x, y + 1));
                }

                k--;
            }

            return result;
        }
    }

    // <summary>
    /// Comparer for comparing two keys, handling equality as beeing greater
    /// Use this Comparer e.g. with SortedLists or SortedDictionaries, that don't allow duplicate keys
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
    {
        public int Compare(TKey x, TKey y)
        {
            int result = x.CompareTo(y);
            if (result == 0)
                return 1;   // Handle equality as beeing greater
            else
                return result;

            //int result = x.CompareTo(y);
            //return result == 0 ? 1 : result;
        }
    }
}
