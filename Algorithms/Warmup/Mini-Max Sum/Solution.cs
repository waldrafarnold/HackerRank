// https://www.hackerrank.com/challenges/mini-max-sum/problem

using System;

class Solution
{

    // Complete the miniMaxSum function below.
    static void miniMaxSum(int[] arr)
    {
        long sum = arr[0];
        long min = arr[0];
        long max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            sum += arr[i];
            if (arr[i] > max)
            {
                max = arr[i];
            }
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }
        Console.WriteLine($"{sum-max} {sum-min}");

    }

    static void Main(string[] args)
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        miniMaxSum(arr);
    }
}
