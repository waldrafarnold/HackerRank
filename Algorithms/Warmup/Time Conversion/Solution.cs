// https://www.hackerrank.com/challenges/time-conversion/problem

using System;
using System.IO;

class Solution
{

    /*
     * Complete the timeConversion function below.
     */
    static string timeConversion(string s)
    {
        bool isAM = s.EndsWith("AM");
        s = s.Substring(0, s.Length - 2);
        if (isAM)
        {
            if (s.StartsWith("12")) {
                return $"00{ s.Substring(2)}";
            }
            return s;
        }
        if (s.StartsWith("12"))
        {
            return s;
        }
        int hours = int.Parse(s.Substring(0, 2)) + 12;
        return $"{hours}{s.Substring(2)}";
    }

    static void Main(string[] args)
    {
        TextWriter tw = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = timeConversion(s);

        tw.WriteLine(result);

        tw.Flush();
        tw.Close();
    }
}