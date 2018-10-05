// https://www.hackerrank.com/challenges/breaking-best-and-worst-records/problem

using System.IO;
using System;

class Solution
{

    enum Item
    {
        Highest = 0,
        Lowest = 1
    }

    // Complete the breakingRecords function below.
    static int[] breakingRecords(int[] scores)
    {
        int[] records = new int[2] { scores[0], scores[0] };
        int[] count = new int[2] { 0, 0 };

        for (int i = 1; i < scores.Length; i++)
        {
            if (scores[i] > records[(int)Item.Highest])
            {
                records[(int)Item.Highest] = scores[i];
                count[(int)Item.Highest]++;
            }
            if (scores[i] < records[(int)Item.Lowest])
            {
                records[(int)Item.Lowest] = scores[i];
                count[(int)Item.Lowest]++;
            }
        }

        return count;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp))
        ;
        int[] result = breakingRecords(scores);

        textWriter.WriteLine(string.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}