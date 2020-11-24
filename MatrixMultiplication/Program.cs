using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace MatrixMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            Console.WriteLine("Enter Random integers(1 to 10) Matrix 1 Columns count to test: ");
            int arr1ColumnsSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Random integers(1 to 10) Matrix 1 Rows count to test: ");
            int arr1RowsSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Random integers(1 to 10) Matrix 2 Columns count to test: ");
            int arr2ColumnsSize = int.Parse(Console.ReadLine());

            var matrixA = RandomMatrix(arr1ColumnsSize, arr1RowsSize);
            var matrixB = RandomMatrix(arr2ColumnsSize, arr1RowsSize);
            Console.WriteLine("Matrix 1");
            PrintMatrix(matrixA);
            Console.WriteLine("Matrix 2");
            PrintMatrix(matrixB);

            stopwatch.Start();
            var br = new BruteForce();
            var matrixBR = br.SolveMatrix(matrixA, matrixB);
            stopwatch.Stop();

            Console.WriteLine("Answer via brute force = ");
            PrintMatrix(matrixBR);
            Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds + "ms"); ;
            stopwatch.Restart();
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write('\n');
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(" " + matrix[i, j] + " ");
                }
            }

            Console.Write('\n');
        }

        public static int[,] RandomMatrix(int columnCount, int rowCount)
        {
            int[,] matrix = new int[rowCount, columnCount];
            Random random = new Random();
            for (int i = 0;i<rowCount;i++)
            {
                for(int j=0;j<columnCount;j++)
                {
                    matrix[i,j] = random.Next(-5, 5);
                }
            }


            return matrix;
        }
    }
}
