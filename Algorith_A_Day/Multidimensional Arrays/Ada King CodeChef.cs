using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Multidimensional_Arrays
{
    /// <summary>
    /// Goal: place a king and some obstacles on a chessboard in such a way
    /// that the number of distinct cells the king can reach is exactly K(input from the user here)
    /// Chessboard is 8X8.
    ///for //K = 5 
    //........
    //........
    //........
    //........
    //........
    //XXX.....
    //..XX....
    //O..X....
    /// </summary>
    public class Ada_King_CodeChef
    {
        public static string[][] GetFilledBoard()
        {
            Console.WriteLine("Enter number from 1-64:");
            int input = int.Parse(Console.ReadLine());
            if (input > 64 || input < 1)
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
                    else if (board[i][j] != "O") board[i][j] = "X";
                    Console.Write(board[i][j]);
                }
                Console.WriteLine();
            }

            return board;
        }
    }
}
