using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixMultiplication
{
    class BruteForce
    {
        public int[,] SolveMatrix(int[,] matrixOne, int[,] matrixTwo)
        {
            int[,] result = new int[matrixOne.GetLength(0), matrixTwo.GetLength(1)];
            for(int i =0;i<matrixOne.GetLength(0);i++)
            {
                for(int j = 0;j< matrixTwo.GetLength(1);j++)
                {
                    result[i, j] = 0;
                    for(int k = 0;k<matrixOne.GetLength(0);k++)
                    {
                        result[i, j] += matrixOne[i, k] * matrixTwo[k, j];
                    }
                }
            }

            return result;
        }
    }
}
