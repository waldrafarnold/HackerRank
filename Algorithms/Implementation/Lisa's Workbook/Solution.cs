// https://www.hackerrank.com/challenges/lisa-workbook/problem

using System.IO;
using System;

class Solution
{

    // Complete the workbook function below.
    static int workbook(int n, int k, int[] arr)
    {
        int result = 0;
        var currentPage = 0;
        foreach (var problemsPerChapter in arr)
        {
            var remainingProblems = problemsPerChapter;
            var firstQuestion = 1 - k;
            var lastQuestion = 0;

            while (remainingProblems > 0)
            {
                currentPage++;
                firstQuestion += k;
                if (remainingProblems >= k)
                    lastQuestion += k;
                else
                    lastQuestion += remainingProblems;

                if (currentPage >= firstQuestion && currentPage <= lastQuestion)
                    result++;

                remainingProblems -= k;
            }
        }
        return result;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int result = workbook(n, k, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
