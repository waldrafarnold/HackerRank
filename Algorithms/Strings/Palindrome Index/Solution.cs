// https://www.hackerrank.com/challenges/palindrome-index/problem
using System.IO;
using System;

class Solution
{

    // Complete the palindromeIndex function below.
    static int palindromeIndex(string s)
    {
        int outputIndex = -1;
        bool removal = false;

        for (int i = 0, j = s.Length - 1; i < j; i++, j--)
        {
            if (s[i] != s[j])
            {
                if (removal)
                {
                    removal = false;
                    outputIndex = -1;
                    break;
                }

                if (s[i + 1] == s[j])
                {
                    removal = true;
                    outputIndex = i;
                    i++;
                }
                else if (s[i] == s[j - 1])
                {
                    removal = true;
                    outputIndex = j;
                    j--;
                }
                else
                {
                    removal = false;
                    outputIndex = -1;
                    break;
                }
            }
        }
        if (outputIndex != -1)
        {
            return outputIndex;
        }

        // swapping check order

        for (int i = 0, j = s.Length - 1; i < j; i++, j--)
        {
            if (s[i] != s[j])
            {
                if (removal)
                {
                    return -1;
                }

                if (s[i] == s[j - 1])
                {
                    removal = true;
                    outputIndex = j;
                    j--;
                }
                else if (s[i + 1] == s[j])
                {
                    removal = true;
                    outputIndex = i;
                    i++;
                }
                else
                {
                    return -1;
                }
            }
        }
        return outputIndex;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = palindromeIndex(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}