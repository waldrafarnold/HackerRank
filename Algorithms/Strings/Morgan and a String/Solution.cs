/*
https://www.hackerrank.com/challenges/morgan-and-a-string

Jack and Daniel are friends. Both of them like letters, especially upper-case ones. 
They are cutting upper-case letters from newspapers, and each one of them has his collection of letters stored in a stack.

One beautiful day, Morgan visited Jack and Daniel. He saw their collections. He wondered what is the lexicographically minimal string made of those two collections. He can take a letter from a collection only when it is on the top of the stack. Morgan wants to use all of the letters in their collections.

As an example, assume Jack has collected  and Daniel has . Assembling the string would go as follows:

Jack	Daniel	Result
ACA	BCF
CA	BCF	A
CA	CF	AB
A	CF	ABC
A	CF	ABCA
    	F	ABCAC
    		ABCACF
Note the choice when there was a tie at CA and CF.

Input Format

The first line contains the an integer , the number of test cases.

The next  pairs of lines are as follows: 
- The first line contains string  
- The second line contains string .

Constraints

 and  contain upper-case letters only, ascii[A-Z].
Output Format

Output the lexicographically minimal string  for each test case in new line.

Sample Input

2
JACK
DANIEL
ABACABA
ABACABA
Sample Output

DAJACKNIEL
AABABACABACABA
Explanation

The first letters to choose from were J and D since they were at the top of the stack. D was chosen, the options then were J and A. A chosen. Then the two stacks have J and N, so J is chosen. (Current string is DAJ) Continuing this way till the end gives us the resulting string.
 
solution inspired from https://github.com/ARYANKAUSHIK/HackerRank-1/blob/master/Algorithms/Strings/Morgan%20and%20a%20String/Solution.java 
 */

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
