//https://www.hackerrank.com/challenges/plus-minus
//Plus Minus
using System.Linq;
using System;

class Solution
{

    // Complete the plusMinus function below.
    static void plusMinus(int[] arr)
    {
        float countPositive = 0;
        float countNegative = 0;
        float countZeros = 0;
        foreach (var a in arr)
        {
            if (a > 0)
            {
                countPositive++;
            }
            else if (a < 0)
            {
                countNegative++;
            }
            else
            {
                countZeros++;
            }
        }
        Console.WriteLine((countPositive / arr.Count()).ToString("N6"));
        Console.WriteLine((countNegative / arr.Count()).ToString("N6"));
        Console.WriteLine((countZeros / arr.Count()).ToString("N6"));
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        plusMinus(arr);
    }
}