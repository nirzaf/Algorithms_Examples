using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class Count_Matrix_LC_1351_E
    {
        public int CountNegatives(int[][] grid)
        {
            if (grid == null || grid.Length == 0) return 0;

            int result = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] < 0) result++;
                }
            }



            return result;
        }

        //public int CountNegatives(int[][] grid)
        //{
        //    if (grid == null || grid.Length == 0) return 0;

        //    int result = 0;

        //    for (int i = 0; i < grid.Length; i++)
        //    {
        //        for (int j = grid[i].Length - 1; j >= 0; j--)
        //        {
        //            if (grid[i][j] < 0) result++;
        //            else continue;
        //        }
        //    }

        //    return result;
        //}

    }
}
