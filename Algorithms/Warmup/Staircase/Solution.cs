//https://www.hackerrank.com/challenges/staircase
//Staircase
using System;

class Solution
{

    // Complete the staircase function below.
    static void staircase(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(i >= n - j - 1 ? "#" : " ");
            }
            Console.WriteLine();
        }

    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        staircase(n);
    }
}