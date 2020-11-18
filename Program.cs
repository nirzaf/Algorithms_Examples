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
using Algorithm_A_Day.MathRelated.Pramp;
using Algorithm_A_Day.Patterns.ModifiedBinarySearch;
using Algorithm_A_Day.Patterns.K_way_Merge;
using Algorithm_A_Day.Patterns.DP_01Knapsack;
using Algorithm_A_Day.Extensions;
using Algorithm_A_Day.Patterns.K_thLargestElement;
using Algorithm_A_Day.MathRelated;
using System.Reflection;
using Algorithm_A_Day.Multidimensional_Arrays;
using System.Numerics;
using Algorithm_A_Day.RandomEasy;
using Algorithm_A_Day.String_operations.Pramp;
using Algorithm_A_Day.DP;
using Algorithm_A_Day.Arrays;
using Algorithm_A_Day.Backtracking;
using Algorithm_A_Day.Recursion;
using System.Collections;

namespace Algorith_A_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bands = { "ACDC", "Queen", "Aerosmith", "Iron Maiden", "Megadeth", "Queen", "Metallica", "Cream", "Oasis",
                "Abba", "Blur", "Chic", "Eurythmics", "Genesis", "INXS", "Midnight Oil", "Kent", "Queen", "Madness", "Manic Street Preachers",
                "Noir Desir", "The Offspring", "Pink Floyd", "Oasis", "Rammstein", "Queen", "Red Hot Chili Peppers", "Tears for Fears", "Deep Purple", "KISS", "Oasis" };

            TreeNode tree = new TreeNode(5, new TreeNode(4, new TreeNode(11, new TreeNode(7, null, null), new TreeNode(2, null, null)), null),
                                new TreeNode(8, new TreeNode(13, null, null), new TreeNode(4, new TreeNode(5, null, null), new TreeNode(1, null, null))));

            TreeNode tree3 = new TreeNode(3, new TreeNode(9, null, null), new TreeNode(20, new TreeNode(15, null, null), new TreeNode(7, null, null)));
            TreeNode tree4 = new TreeNode(2147483647, new TreeNode(2147483647, null, null), new TreeNode(2147483647, null, null));

            Node tree1 = new Node(1, new Node(3, new Node(5, null, null), new Node(4, null, null)),
                                new Node(2, new Node(3, null, null), new Node(8, null, null)));
            // linked list
            ListNode x1 = new ListNode(1), x2 = new ListNode(2), x3 = new ListNode(3), x4 = new ListNode(4), x5 = new ListNode(5);
            x1.next = x2;
            x2.next = x3;
            x3.next = x4;
            x4.next = x5;

            ListNode y1 = new ListNode(1), y2 = new ListNode(3), y3 = new ListNode(4);
            y1.next = y2;
            y2.next = y3;

            ListNode z1 = new ListNode(2), z2 = new ListNode(6);
            z1.next = z2;

            var listOfLN = new ListNode[] { x1, y1, z1 };


            

            int[][] intervals = new int[3][];
            intervals[0] = new[] { 1, 2, 3 };
            intervals[1] = new[] { 4, 5, 6 };
            intervals[2] = new[] { 7, 8, 9 };
            //intervals[3] = new[] { 1, 3 };
            
            int[][] arrOfArrays = new int[4][];
            arrOfArrays[0] = new[] { 5, 1, 9, 11 };
            arrOfArrays[1] = new[] { 2, 4, 8, 10 };
            arrOfArrays[2] = new[] { 13, 3, 6, 7 };
            arrOfArrays[3] = new[] { 15, 14, 12, 16 };

            var arrOfArrays2 = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }

            };

            // each array len must be the same
            int[,] TwoDArray = new int[3, 4] {
                { 1, 2, 3, 8 },
                { 4, 5, 6, 9 },
                { 7, 8, 9, 10 }
            };

            var z = 2.82842;
            int o = Convert.ToInt32(z);// rounds to 3 so 2.455->2  (no ceiling 2.1 -> 3)
            int p = (int)z; // it floors to 2


            var testArr = new int[] { 2, 5, 1, 3, 4, 7 };
            var sortedArr = new int[] { 1, 2, 3 };
            var mixedArr = new int[] { 1, 1, 2, 2, 4 };
            var mixedArr2 = new string[] { "flower", "flow", "flight" };
            var charA = new char[] { 'h', 'e', 'l', 'l', 'o' };


            //Swap_Nodes_in_Pairs_LC_24_M.SwapPairs2(x1);
            Defanging_an_IP_Address_1108_E.DefangIPaddr4("1.1.1.1");


        }


        //private static int Yesterday(int n)
        //{
           
        //}

    }

    
}
