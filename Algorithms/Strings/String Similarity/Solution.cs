// https://www.hackerrank.com/challenges/string-similarity
// Terminated due to timeout - test 10 and 11;

using System.IO;
using System;

class Solution
{
    // Complete the stringSimilarity function below.
    static int stringSimilarity(string s)
    {
        int result = s.Length;
        for (int i = 1; i < s.Length; i++)
        {
            int j = 0;
            while ((i + j < s.Length) && (s[j] == s[i + j]))
            {
                result++;
                j++;
            }
        }

        return result;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string s = Console.ReadLine();

            int result = stringSimilarity(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}