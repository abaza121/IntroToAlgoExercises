using System;
using System.Diagnostics;

namespace IntroToAlgoExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            Console.WriteLine("Enter Random integers(-50 to 50) Array size to test: ");
            int arrSize = int.Parse(Console.ReadLine());
            int[] testArr = BuildBigArray(100000);
            stopwatch.Start();
            var br = new BruteForce();
            var subarr = br.SolveArray(testArr);
            stopwatch.Stop();
            Console.WriteLine(subarr.low + " " + subarr.high + " " + stopwatch.ElapsedMilliseconds + "ms");
            stopwatch.Restart();
            var dac = new DivideAndConquer();
            subarr = dac.SolveArray(testArr);
            stopwatch.Stop();
            Console.WriteLine(subarr.low + " " + subarr.high + " " + stopwatch.ElapsedMilliseconds + "ms");
        }

        public static int[] BuildBigArray(int count)
        {
            Random random = new Random();
            int[] arr = new int[count];
            for (int i = 0; i < count; i++)
            {
                arr[i] = random.Next(-50, 50);
            }

            return arr;
        }
    }
}
