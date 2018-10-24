//https://www.hackerrank.com/challenges/sum-vs-xor
using System.IO;
using System;

class Solution
{

    // Complete the sumXor function below.
    static long sumXor(long n)
    {
        long result = 0;
        //get count of 0 digits from the number transformed into binary
        while (n != 0)
        {
            result += (n % 2 == 0) ? 1 : 0;
            n /= 2;
        }
        result = (long)Math.Pow(2, result);
        return result;

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        long n = Convert.ToInt64(Console.ReadLine().Trim());

        long result = sumXor(n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
