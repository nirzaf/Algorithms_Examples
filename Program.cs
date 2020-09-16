using Algorithm_A_Day.BinarySearch;
using Algorithm_A_Day.NodesModels;
using Algorithm_A_Day.Grid_Based;
using Algorithm_A_Day.Patterns._2Pointers;
using Algorithm_A_Day.Patterns.BFS;
using Algorithm_A_Day.Patterns.DFS;
using Algorithm_A_Day.Patterns.Sliding_Window;
using Algorithm_A_Day.Sorting;
using Algorithm_A_Day.Sorting.MergeSort;
using Algorithm_A_Day.String_operations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO.Pipes;
using System.Linq;
using System.Net.Sockets;
using Algorithm_A_Day.Patterns.FastAndSlowPointers;
using Algorithm_A_Day.Patterns.MergeIntervals;
using Algorithm_A_Day.Patterns.CyclicSort;
using Algorithm_A_Day.Patterns.ReverseLinkedList;
using Algorithm_A_Day.Arrays.Arrays.Pramp;
using Algorithm_A_Day.Arrays.LeetCode;
using Algorithm_A_Day.Patterns.Subsets;

namespace Algorith_A_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bands = { "ACDC", "Queen", "Aerosmith", "Iron Maiden", "Megadeth", "Queen", "Metallica", "Cream", "Oasis",
                "Abba", "Blur", "Chic", "Eurythmics", "Genesis", "INXS", "Midnight Oil", "Kent", "Queen", "Madness", "Manic Street Preachers",
                "Noir Desir", "The Offspring", "Pink Floyd", "Oasis", "Rammstein", "Queen", "Red Hot Chili Peppers", "Tears for Fears", "Deep Purple", "KISS", "Oasis" };

            TreeNode tree = new TreeNode(1, new TreeNode(3, new TreeNode(5, null, null), new TreeNode(4, null, null)),
                                new TreeNode(2, new TreeNode(3, null, null), new TreeNode(8, null, null)));

            Node tree1 = new Node(1, new Node(3, new Node(5, null, null), new Node(4, null, null)),
                                new Node(2, new Node(3, null, null), new Node(8, null, null)));
            //cycled linked list
            ListNode x1 = new ListNode(1), x2 = new ListNode(2), x3 = new ListNode(3), x4 = new ListNode(4), x5 = new ListNode(5);
            x1.next = x2;
            x2.next = x3;
            x3.next = x4;


            

            int[][] intervals = new int[4][];
            intervals[0] = new[] { 15, 18 };
            intervals[1] = new[] { 2, 6 };
            intervals[2] = new[] { 8, 10 };
            intervals[3] = new[] { 1, 3 };
            
            int[][] arrOfArrays = new int[3][];
            arrOfArrays[0] = new[] { 2, 1, 1 };
            arrOfArrays[1] = new[] { 1, 1, 0 };
            arrOfArrays[2] = new[] { 0, 1, 1 };

            var arrOfArrays2 = new int[][]
            {
                new int[] {1, 2, 3},
                new int[] {4, 5, 6},
                new int[] {7, 8, 9}
            };

            int[,] Arr2D = new int[3, 2] {
            { 1, 2 },
            { 2, 3 },
            { 3, 4 }
            };

            var testArr = new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
            var sortedArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 15, 21, 50, 200, 400 };
            var mixedArr = new int[] { 1, 2, 3 };

            Subsets_LC_78.SubsetsRecur(mixedArr);



        }
        //  0  1  2  3  4  5
        //{ 2, 1, 5, 6, 7, 3 };
        //{ 0,1,2,2,3,0,4,2 };

        //naive solution
        //public static IList<IList<int>> LevelOrder(TreeNode root)
        //{

        //}

        //private static int[][] Example(int[] nums1, int k)
        //{
        //    //var result = new List<int[]>();
        //    //for (int i = 0; i < nums1.Length -1; i++)
        //    //{
        //    //    for (int j = i + 1; j < nums1.Length; j++)
        //    //    {
        //    //        if (nums1[j] - nums1[i] == k)
        //    //        {
        //    //            result.Add(new int[] { nums1[j], nums1[i] });
        //    //        }
        //    //        else if (nums1[i] - nums1[j] == k)
        //    //        {
        //    //            result.Add(new int[] { nums1[i], nums1[j] });
        //    //        }

        //    //    }
        //    //}

        //    //return result.ToArray();

        //    var result = new List<int[]>();
        //    var dict = new Dictionary<int, int>();


        //}



    }

}
