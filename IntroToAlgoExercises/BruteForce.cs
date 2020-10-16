using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToAlgoExercises
{
    class BruteForce
    {
        public SubArray SolveArray(int[] arr)
        {
            var sum = int.MinValue;
            SubArray subArray = null;
            for(int i =0; i< arr.Length;i++)
            {
                var newSum = 0;
                for (int j = i;j<arr.Length;j++)
                {
                    newSum += arr[j];
                    if (newSum > sum)
                    {
                        sum = newSum;
                        subArray = new SubArray(i, j);
                    }
                }

                newSum = 0;
                for (int j = 0; j <= i; j++)
                {
                    newSum += arr[j];
                    if (newSum > sum)
                    {
                        sum = newSum;
                        subArray = new SubArray(j, i);
                    }
                }
            }

            return subArray;
        }
    }

    class SubArray
    {
        public int low;
        public int high;

        public SubArray(int low, int high)
        {
            this.low = low;
            this.high = high;
        }
    }
}
