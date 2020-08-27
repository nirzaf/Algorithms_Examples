using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.BFS
{
    /// <summary>
    /// LeetCode 994
    /// TC = O(n) ---> inner loop in nested loop but it iterates 4 times every time , SC = O(n)
    /// </summary>
    public class Rotting_Oranges
    {
        public static int OrangesRotting(int[][] grid)
        {
            int rotten = 0, fresh = 0, minutes = 0;
            int rottenInMinute = 0;
            int rows = grid.Length;
            int cols = grid[0].Length; // we asumme it is a square

            var rottenQueue = new Queue<(int R, int C)>();

            //get initial state of the board
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if(grid[i][j] == 2)
                    {
                        rotten++;
                        rottenQueue.Enqueue((i, j));

                    }else if(grid[i][j] == 1)
                    {
                        fresh++;
                    }
                }
            }

            // ARRAY of tuples
            var directions = new ValueTuple<int, int>[]
                { (1, 0), (0, -1), (-1, 0), (0, 1) };
            

            while(rottenQueue.Count > 0)
            {
                var orange = rottenQueue.Dequeue();
                rotten--;

                foreach (var item in directions)
                {
                    // value of orange around  
                    int i = orange.R + item.Item1;
                    int j = orange.C + item.Item2;
                    //check the boundaries
                    if(i < 0 || i > rows - 1 || j < 0 || j > cols - 1) { continue; } 
                    
                    if(grid[i][j] == 1)
                    {
                        grid[i][j] = 2;
                        fresh--;rottenQueue.Enqueue((i, j));
                        rottenInMinute++;
                    }
                       
                }
            }

            if(rotten == 0 && rottenInMinute > 0)
            {
                minutes++;
                rotten = rottenInMinute;
                rottenInMinute = 0;
            }

            return (fresh == 0) ? minutes : -1;      
        }

    }
}
