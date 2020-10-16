using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IntroToAlgoExercises
{
    class DivideAndConquer
    {
        public SubArray SolveArray(int[] arr)
        {
            return FindMaxSubArray(arr, 0, arr.Length-1).Item1;
        }

        public (SubArray, int) FindMaxSubArray(int[] arr, int low, int high)
        {
            if(high == low)
            {
                return (new SubArray(low, high), arr[low]);
            }
            else
            {
                var mid = (low + high) / 2;
                (SubArray, int) left = FindMaxSubArray(arr, low, mid);
                (SubArray, int) right = FindMaxSubArray(arr, mid + 1, high);
                (SubArray, int) cross = FindMaxCrossingSubArray(arr, low,  mid, high);

                if (left.Item2 >= right.Item2 && left.Item2 >= cross.Item2)
                    return left;
                else if (right.Item2 >= left.Item2 && right.Item2 >= cross.Item2)
                    return right;
                else return cross;
            }
        }

        public (SubArray, int) FindMaxCrossingSubArray(int[] arr, int low, int mid, int high)
        {
            var leftsum = int.MinValue;
            var sum = 0;
            var maxleft = 0;
            for(int i = mid; i >= low; i--)
            {
                sum += arr[i];
                if(sum > leftsum)
                {
                    leftsum = sum;
                    maxleft = i;
                }
            }

            var rightsum = int.MinValue;
            var maxright = 0;
            sum = 0;
            for (int i = mid + 1; i <= high; i++)
            {
                sum += arr[i];
                if (sum > rightsum)
                {
                    rightsum = sum;
                    maxright = i;
                }
            }

            return (new SubArray(maxleft, maxright), leftsum + rightsum);
        }
    }
}
