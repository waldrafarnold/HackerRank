// https://www.hackerrank.com/challenges/morgan-and-a-string

using System.IO;
using System.Text;
using System;

class Solution
{

    // Complete the morganAndString function below.
    static string morganAndString(string a, string b)
    {
        StringBuilder output = new StringBuilder();
        int i = 0;
        int j = 0;

        StringBuilder s1 = new StringBuilder(a); s1.Append("z");
        StringBuilder s2 = new StringBuilder(b); s2.Append("z");

        while (i < s1.Length && j < s2.Length)
        {
            if (s1[i] < s2[j])
            {
                output.Append(s1[i]);
                i++;
            }
            else if (s1[i] > s2[j])
            {
                output.Append(s2[j]);
                j++;
            }
            else
            {
                if (s1[i] == 'z')
                {
                    i++;
                    j++;
                    continue;
                }

                int startingI = i;
                int startingJ = j;

                while (s1[i] == s2[j]) // find where the strings become different
                {
                    i++;
                    j++;
                    if (i >= s1.Length && j >= s2.Length) // identical strings
                    {
                        i = startingI;
                        j = startingJ;
                        break;
                    }
                    else if (i >= s1.Length) //s1 is shorter
                    {
                        //Append all chars that are in a decreasing sequence 
                        //gdbad returns gdba
                        char prev = s2[startingJ];
                        while (s2[startingJ] <= prev)
                        {
                            output.Append(s2[startingJ]);
                            prev = s2[startingJ];
                            startingI++;
                        }
                        i = startingI;
                        j = startingJ;
                    }
                    else if (j >= s2.Length) //s2 is shorter
                    {
                        char prev = s1[startingI];
                        while (s1[startingI] <= prev)
                        {
                            output.Append(s1[startingI]);
                            prev = s1[startingI];
                            startingI++;
                        }
                        i = startingI;
                        j = startingJ;
                    }
                }

                //different strings
                //s1 is lexicographically smaller than s2
                if (s1[i] <= s2[j])
                {
                    char prev = s1[startingI];
                    while (s1[startingI] <= prev)
                    {
                        output.Append(s1[startingI]);
                        prev = s1[startingI];
                        startingI++;
                    }
                    i = startingI;
                    j = startingJ;
                }

                //s2 is lexicographically smaller than s1
                if (s1[i] > s2[j])
                {
                    char prev = s2[startingJ];
                    while (s2[startingJ] <= prev)
                    {
                        output.Append(s2[startingJ]);
                        prev = s2[startingJ];
                        startingJ++;
                    }
                    i = startingI;
                    j = startingJ;
                }
            }
        }

        //We reached the end of a string
        //Add rest of st1
        while (i < s1.Length)
        {
            output.Append(s1[i]);
            i++;
        }

        //Add rest of st2
        while (j < s2.Length)
        {
            output.Append(s2[j]);
            j++;
        }

        return output.ToString();
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string a = Console.ReadLine();

            string b = Console.ReadLine();

            string result = morganAndString(a, b);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
