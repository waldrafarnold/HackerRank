//https://www.hackerrank.com/challenges/the-love-letter-mystery

using System.IO;
using System;

class Solution
{

    // Complete the theLoveLetterMystery function below.
    static int theLoveLetterMystery(string s)
    {
        var result = 0;
        for (int i = 0; i< s.Length / 2; i++)
        {
            result += Math.Abs((int)s[i] - (int)s[s.Length - 1 - i]);
        }
        return result;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = theLoveLetterMystery(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}