using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.DFS
{
    /// <summary>
    /// Here we need to do dfs. To keep track of current island
    /// we need to do recursive call in all 4 direction with boundaries
    /// where boundaries are the grid boundaries plus that current point cant be 0
    /// every call we need to 'sink' the island in a way that
    /// we modify the grid changing '1s' into diffriend char f.e '0'
    /// </summary>
    public class Number_Of_Islands_LC_200
    {
        //recursive solution
        public static int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0) return 0;
            int result = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        result++;
                        DFS(grid, i, j);
                    }
                }
            }

            
            return result;
        }

        private static void DFS(char[][] grid, int i, int j)
        {
            if( i < 0 || i >= grid.Length ||
                j < 0 || j >= grid[i].Length ||
                grid[i][j] == '0')
            {
                return;
            }

            grid[i][j] = '0';

            DFS(grid, i, j + 1);
            DFS(grid, i, j - 1);
            DFS(grid, i + 1, j);
            DFS(grid, i - 1, j);
        }
        //iterative solution

        public static int NumIslandsIter(char[][] grid)
        {
            int result = 0;
            var toVisit = new Stack<int[]>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if(grid[i][j] == '1')
                    {
                        //recursion simulation
                        toVisit.Push(new int[] { i, j });
                        while (toVisit.Count > 0)
                        {
                            int[] current = toVisit.Pop();
                            int currRow = current[0];
                            int currCol = current[1];

                            if (currRow < 0 || currRow >= grid.Length ||
                                currCol < 0 || currCol >= grid[0].Length ||
                                grid[currRow][currCol] != '1')
                            {
                                continue;
                            }
                            grid[currRow][currCol] = '0';

                            toVisit.Push(new int[] { currRow + 1, currCol });
                            toVisit.Push(new int[] { currRow -1, currCol });
                            toVisit.Push(new int[] { currRow, currCol + 1 });
                            toVisit.Push(new int[] { currRow, currCol -1 });
                        }
                        // end of recursion
                        result++;
                    }
                }
            }




            return result;
        }
        // BFS solution
        public static int NumIslandsBFS(char[][] grid)
        {
            int result = 0;
            var toVisit = new Queue<int[]>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if(grid[i][j] == '1')
                    {
                        //recursion simulation
                        toVisit.Enqueue(new int[] { i, j });
                        while (toVisit.Count > 0)
                        {
                            int[] current = toVisit.Dequeue();
                            int currRow = current[0];
                            int currCol = current[1];

                            if (currRow < 0 || currRow >= grid.Length ||
                                currCol < 0 || currCol >= grid[0].Length ||
                                grid[currRow][currCol] != '1')
                            {
                                continue;
                            }
                            grid[currRow][currCol] = '0';

                            toVisit.Enqueue(new int[] { currRow + 1, currCol });
                            toVisit.Enqueue(new int[] { currRow -1, currCol });
                            toVisit.Enqueue(new int[] { currRow, currCol + 1 });
                            toVisit.Enqueue(new int[] { currRow, currCol -1 });
                        }
                        // end of recursion
                        result++;
                    }
                }
            }




            return result;
        }
    }
}
