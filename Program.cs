using Algorithm_A_Day.Arrays.Mix;
using Algorithm_A_Day.BinarySearch;
using Algorithm_A_Day.Grid_Based;
using Algorithm_A_Day.Sorting.BubbleSort;
using System;
using System.Diagnostics.Tracing;

namespace Algorith_A_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            var testArr = new int[] { 0, -1, -2, 2, 1 };
            var sortedArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 15, 21, 50, 200, 400 };
            var mixedArr = new int[] { 1, 4, 6, 8, 9 };
            var a = new int[] { 2, 0, 2, 1, 1, 0 };

            SortColors.SortColorsMethod(a);
            //King();
            Pairs_with_Specific_Difference___pramp.FindPairsWithGivenDifference2(testArr, 1); 
        }

        public static string[][] King()
        {
            Console.WriteLine("Enter number from 1-64:");
            int input = int.Parse(Console.ReadLine());
            if(input > 64 || input < 1)
            {
                throw new Exception("Wrong input");
            }

            string[][] board = new string[8][];
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = new string[] { ".", ".", ".", ".", ".", ".", ".", "." };
            }
            board[0][0] = "O";
            int counter = 1;

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (counter < input && board[i][j] != "O")
                    {
                        counter++;
                    }
                    else if(board[i][j] != "O") board[i][j] = "X";
                    Console.Write(board[i][j]);
                }
                Console.WriteLine();
            }

            return board;
        }
    }
}
