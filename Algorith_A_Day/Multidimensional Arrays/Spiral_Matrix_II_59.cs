using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Multidimensional_Arrays
{
    public class Spiral_Matrix_II_59
    {
        public static int[][] GenerateMatrix(int n)
        {
            if (n < 0) throw new ArgumentException();

            var result = new int[n][];
            if (n == 0) return result;

            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
            }

            int currentColumn = 0;
            int currentRow = 0;
            int lastColumn = n - 1;
            int lastRow = n - 1;
            int currentNumber = 0;

            while (currentRow <= lastRow && currentColumn <= lastColumn)
            {
                for (int i = currentColumn; i <= lastColumn; i++)
                {
                    result[currentRow][i] = currentNumber + 1;
                    currentNumber++;
                }
                currentRow++;
    

            for (int i = currentRow; i <= lastRow; i++)
                {
                    result[i][lastColumn] = currentNumber + 1;
                    currentNumber++;
                }
                lastColumn--;

                if (currentRow <= lastRow)
                {
                    for (int i = lastColumn; i >= currentColumn; i--)
                    {
                        result[lastRow][i] = currentNumber + 1;
                        currentNumber++;
                    }
                    lastRow--;
                }

                if (currentColumn <= lastColumn)
                {
                    for (int i = lastRow; i >= currentRow; i--)
                    {
                        result[i][currentColumn] = currentNumber + 1;
                        currentNumber++;
                    }
                    currentColumn++;
                }
            }
            return result;

        }
    }
}
