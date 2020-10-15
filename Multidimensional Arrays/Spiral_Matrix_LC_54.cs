using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Algorithm_A_Day.Multidimensional_Arrays
{
    public class Spiral_Matrix_LC_54
    {
        /// <summary>
        ///         curr.c      last.c  
        ///curr.r   [ 1, 2, 3, 8 ,9 ],
        ///         [ 4, 5, 6, 7, 8 ],
        ///         [ 7, 8, 9, 0, 6 ],
        ///  last.r [ 2, 5, 5, 5, 9 ]
        /// </summary>

        public static IList<int> SpiralOrder(int[][] matrix)
        {
            var result = new List<int>();
            if (matrix == null || matrix.Length == 0) return result;

            int currentColumn = 0; 
            int currentRow = 0; 
            int lastColumn = matrix[0].Length -1;
            int lastRow = matrix.Length -1;


            while (currentRow <= lastRow &&
                    currentColumn <= lastColumn)
            {
                for (int i = currentColumn; i <= lastColumn; i++)
                {
                    result.Add(matrix[currentRow][i]);
                }
                currentRow++; 

                for (int i = currentRow; i <= lastRow; i++)
                {
                    result.Add(matrix[i][lastColumn]);
                }
                lastColumn--;

                //checking if it did't go over the last row
                if(currentRow <= lastRow)
                {
                    for (int i = lastColumn; i >= currentColumn; i--)
                    {
                        result.Add(matrix[lastRow][i]);
                    }
                    lastRow--;
                }
                //checking if it did't go over the last column
                if (currentColumn <= lastColumn)
                {
                    for (int i = lastRow; i >= currentRow; i--)
                    {
                        result.Add(matrix[i][currentColumn]);
                    }
                    currentColumn++;
                }
                
            }
            return result;
        }
        //2D arrya
        public static int[] SpiralOrder2(int[,] inputMatrix)
        {
            var result = new int[inputMatrix.GetLength(0) * inputMatrix.GetLength(1)];
            if (inputMatrix == null || inputMatrix.Length == 0) return result;

            int index = 0;
            int currentRow = 0;
            int currentColumn = 0;
            int lastRow = inputMatrix.GetLength(0) - 1;
            int lastColumn = inputMatrix.GetLength(1) - 1;


            while (currentRow <= lastRow && currentColumn <= lastColumn)
            {
                for (int i = currentColumn; i <= lastColumn; i++)
                {
                    result[index] = inputMatrix[currentRow, i];
                    index++;
                }
                currentRow++;

                for (int i = currentRow; i <= lastRow; i++)
                {
                    result[index] = inputMatrix[i, lastColumn];
                    index++;
                }
                lastColumn--;

                if(currentRow <= lastRow)
                {
                    for (int i = lastColumn; i >= currentColumn; i--)
                    {
                        result[index] = inputMatrix[lastRow, i];
                        index++;
                    }
                    lastRow--;
                }

                if (currentColumn <= lastColumn)
                {
                    for (int i = lastRow; i >= currentRow; i--)
                    {
                        result[index] = inputMatrix[i, currentColumn];
                        index++;
                    }
                    currentColumn++;
                }
            }
            return result;
        }

        //JS 
        //function spiralCopy(inputMatrix)
        //{
        //    let result = [];
        //    if (inputMatrix === null || inputMatrix.length === 0) return result;

        //    let currentRow = 0;
        //    let currentColumn = 0;
        //    let lastRow = inputMatrix.length - 1;
        //    let lastColumn = inputMatrix[0].length - 1;

        //    while (currentRow <= lastRow && currentColumn <= lastColumn)
        //    {

        //        for (let i = currentColumn; i <= lastColumn; i++)
        //        {
        //            result.push(inputMatrix[currentRow][i]);
        //        };
        //        currentRow++;

        //        for (let i = currentRow; i <= lastRow; i++)
        //        {
        //            result.push(inputMatrix[i][lastColumn]);
        //        };
        //        lastColumn--;

        //        if (currentRow <= lastRow)
        //        {
        //            for (let i = lastColumn; i >= currentColumn; i--)
        //            {
        //                result.push(inputMatrix[lastRow][i]);
        //            };
        //            lastRow--;
        //        };

        //        if (currentColumn <= lastColumn)
        //        {
        //            for (let i = lastRow; i >= currentRow; i--)
        //            {
        //                result.push(inputMatrix[i][currentColumn]);
        //            };
        //            currentColumn++;
        //        };
        //    }
        //    return result;
        //}
    }
}
