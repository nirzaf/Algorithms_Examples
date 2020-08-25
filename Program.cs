using Algorithm_A_Day.Arrays.Mix;
using Algorithm_A_Day.BinarySearch;
using Algorithm_A_Day.BinaryTreeTraversal;
using Algorithm_A_Day.Grid_Based;
using Algorithm_A_Day.Patterns._2Pointers;
using Algorithm_A_Day.Patterns.BFS;
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

            var testArr = new int[] { 1, 2, 3, 4, };
            var sortedArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 15, 21, 50, 200, 400 };
            var mixedArr = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            


            RemoveElement_LC___27.RemoveElement(mixedArr, 2);


        }
        //  0  1  2  3  4  5
        //{ 2, 1, 5, 6, 7, 3 };
        //{ 6, 7, 2, 1, 5, 3 };

        //naive solution
        public static void Yesterdays(int[] arr, int s, int e)
        {
            //base case
            if (s < e)
            {
                int m = (s + e) / 2;
                Yesterdays(arr, s, m);
                Yesterdays(arr, m + 1, e);
                Example(arr, s, m, e);
            }
        }

        private static void Example(int[] arr, int s, int m, int e)
        {
            int k = 0;
            int i = s;
            int j = m + 1;
            var temp = new int[e - s + 1];

            while(i <= m && j <= e)
            {
                if(arr[i] < arr[j])
                {
                    temp[k] = arr[i];
                    k++;
                    i++;
                }
                else
                {
                    temp[k] = arr[j];
                    k++;
                    j++;
                }
            }
            while (i <= m)
            {
                temp[k] = arr[i];
                k++;
                i++;
            }
            while (j <= e)
            {
                temp[k] = arr[j];
                k++;
                j++;
            }

            for (int l = s; l < e; l++)
            {
                arr[l] = temp[l -s];
            }
        }

    }
}
