// https://www.hackerrank.com/challenges/grading/problem

using System;
using System.IO;

class Solution
{

    /*
     * Complete the gradingStudents function below.
     */
    static int[] gradingStudents(int[] grades)
    {
        for (int i = 0; i < grades.Length; i++)
        {
            if (grades[i] < 38)
            {
                continue;
            }
            var lastDigit = grades[i] % 10;
            if (lastDigit == 3)
            {
                grades[i] += 2;
            } 
            else if (lastDigit == 4)
            {
                grades[i] += 1;
            }
            else if (lastDigit == 8)
            {
                grades[i] += 2;
            }
            else if (lastDigit == 9)
            {
                grades[i] += 1;
            }
        }
        return grades;
    }

    static void Main(string[] args)
    {
        TextWriter tw = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] grades = new int[n];

        for (int gradesItr = 0; gradesItr < n; gradesItr++)
        {
            int gradesItem = Convert.ToInt32(Console.ReadLine());
            grades[gradesItr] = gradesItem;
        }

        int[] result = gradingStudents(grades);

        tw.WriteLine(string.Join("\n", result));

        tw.Flush();
        tw.Close();
    }
}
