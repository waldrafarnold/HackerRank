//https://www.hackerrank.com/challenges/compare-the-triplets
//Compare the Triplets
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

class Solution
{

    // Complete the compareTriplets function below.
    static List<int> compareTriplets(List<int> a, List<int> b)
    {
        int alicePoints = a.Where((item, index) => item > b[index]).Count();
        int bobPoints = b.Where((item, index) => item > a[index]).Count();
        return new List<int> { alicePoints, bobPoints };
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        List<int> b = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(bTemp => Convert.ToInt32(bTemp)).ToList();

        List<int> result = compareTriplets(a, b);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}