using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BST.Matrix
{
    static class Matrixes
    {
        const int size3 = 3;

        static int[,] A = new int[size3, size3];

        static int[,] B = new int[size3, size3];

        static int[] a = new int[size3];

        static Random random = new Random();

        //populate matrixes and vector with random numbers
        public static void PopulateMatrixesAndVectorRandomNumbers()
        {
            for (int i = 0; i < size3; i++)
            {
                for (int j = 0; j < size3; j++)
                {
                    A[i, j] = random.Next(1, 10);
                    B[i, j] = random.Next(1, 10);
                }
                a[i] = random.Next(1, 10);
            }
        }

        //SQUARE matrix + matrix addition 
        public static int[,] Add2Matrixes(int[,] matrix1, int[,] matrix2)
        {
            int size = (int)Math.Sqrt(matrix1.Length);
            int[,] result = new int[size,size];
            

            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {
                    var substractionResult = matrix1[j, k] - matrix2[j, k];
                    if(substractionResult < 0)
                    {
                        result[j, k] = 0;
                    }
                    else
                    {
                        result[j, k] = substractionResult;
                    }

                    //result[j, k] = matrix1[j, k] + matrix2[j, k];

                }
            }
            return result;
        }

        //SQUARE sum up matrix entries
        public static int SumMatrixElemenets(int[,] matrix)
        {
            int result = 0;
            int size = (int)Math.Sqrt(matrix.Length);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result += matrix[i, j];
                }
            }

            var result2 = matrix.Cast<int>().Sum();

            var result3 = (from int val in matrix
                           select val).Sum();
            return result2;
        }

        //SQUARE matrix-vector multiplication
        public static int[] MultiplyMatrixByVector(int[] vector, int[,] matrix)
        {
            int[] result = new int[vector.Length];

            for (int i = 0; i < vector.Length; i++)
            {

                for (int j = 0; j < vector.Length; j++)
                {
                    result[i] += vector[j] * matrix[i, j];
                }
            }

            return result;
        }

        //SQUARE matrix-matrix multiplication
        public static int[,] MultiplyMatrixByMatrix(int[,] matrix1, int[,] matrix2)
        {
            int size = (int)Math.Sqrt(matrix1.Length);
            int[,] result = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return result;
        }
        
        //NON-SQUARE matrix-matrix multiplication
        public static int[,] MultiplyNonSquere(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0);
            int rows2 = matrix2.GetLength(0);
            int col1 = matrix1.GetLength(1);
            int col2 = matrix2.GetLength(1);

            if(col1 != rows2) { throw new Exception("Columns of first must be equal to rows of second!"); }

            int[,] result = new int[rows1, col2];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < col2; j++)
                {
                    for (int k = 0; k < rows2; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return result;
        }


        //Jagged/ array of arrays
        public static int JaggedArray()
        {
            int[][] arrOfArrays = new int[3][];
            arrOfArrays[0] = new[] { 1, 2, 3 };
            arrOfArrays[1] = new[] { 4, 5, 6 };
            arrOfArrays[2] = new[] { 7, 8, 9 };

            return 0;
        }
        
    }
}
