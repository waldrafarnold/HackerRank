//https://www.hackerrank.com/challenges/birthday-cake-candles
//Birthday Cake Candles
using System.IO;
using System;

class Solution
{

    // Complete the birthdayCakeCandles function below.
    static int birthdayCakeCandles(int[] ar)
    {
        var count = 1;
        var max = ar[0];
        for (int i = 1; i < ar.Length; i++)
        {
            if (ar[i] > max)
            {
                max = ar[i];
                count = 1;
            }
            else if (ar[i] == max)
            {
                count++;
            }
        }
        return count;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arCount = Convert.ToInt32(Console.ReadLine());

        int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp))
        ;
        int result = birthdayCakeCandles(ar);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}