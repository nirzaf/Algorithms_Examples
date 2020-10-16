using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Multidimensional_Arrays
{
    public class Rotate_Image_LC_48
    {
        public static void Rotate(int[][] matrix)
        {
            //var newMatrix = new int[matrix.Length][];
            //for (int i = 0; i < matrix.Length; i++)
            //{
            //    newMatrix[i] = new int[matrix[i].Length];
            //}
            
            if (matrix == null || matrix.Length == 0) return;

            int lastColumn = matrix[0].Length - 1;
            int index = 0;

            var helper = new List<int[]>();

            for (int i = 0; i < matrix.Length; i++)
            {
                var temp = new int[matrix[i].Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    temp[j] = matrix[i][j];
                }
                helper.Add(temp);
            }

            for (int i = lastColumn; i >= 0; i--)
            {
                var currentArray = helper[index];
                for (int j = 0; j < helper[index].Length; j++)
                {
                    matrix[j][i] = currentArray[j];
                }
                index++;
            }
        }

        public void Rotate2(int[][] matrix)
        {
            var n = matrix.GetLength(0);

            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[n - i - 1][j];
                    matrix[n - i - 1][j] = temp;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
        }

        // instead of calculating the relative position, finding the pattern inside is more helpful.
        // turnover the bottom to top -> then swith the right upper corners to the left down corners.
        //todo: understand
        public void Rotate3(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return;

            for (int i = 0; i < matrix.Length / 2; i++)
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    matrix[i][j] += matrix[matrix.Length - 1 - i][j];
                    matrix[matrix.Length - 1 - i][j] = matrix[i][j] - matrix[matrix.Length - 1 - i][j];
                    matrix[i][j] -= matrix[matrix.Length - 1 - i][j];
                }

            for (int i = 0; i < matrix.Length; i++)
                for (int j = i; j < matrix[0].Length; j++)
                    if (i != j)
                    {
                        matrix[i][j] += matrix[j][i];
                        matrix[j][i] = matrix[i][j] - matrix[j][i];
                        matrix[i][j] -= matrix[j][i];
                    }
        }
    }
}