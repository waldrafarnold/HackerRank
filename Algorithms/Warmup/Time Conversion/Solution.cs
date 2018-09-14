/*
https://www.hackerrank.com/challenges/time-conversion/problem

Given a time in -hour AM/PM format, convert it to military (24-hour) time.

Note: Midnight is 12:00:00AM on a 12-hour clock, and 00:00:00 on a 24-hour clock. Noon is 12:00:00PM on a 12-hour clock, and 12:00:00 on a 24-hour clock.

Function Description

Complete the timeConversion function in the editor below. It should return a new string representing the input time in 24 hour format.

timeConversion has the following parameter(s):

s: a string representing time in  hour format
Input Format

A single string  containing a time in -hour clock format (i.e.:  or ), where  and .

Constraints

All input times are valid
Output Format

Convert and print the given time in -hour format, where .

Sample Input 0

07:05:45PM
Sample Output 0

19:05:45
 */

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