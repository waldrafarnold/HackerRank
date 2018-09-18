/*
https://www.hackerrank.com/challenges/string-similarity
Terminated due to timeout - test 10 and 11;

For two strings A and B, we define the similarity of the strings to be the length of the longest prefix common to both strings. For example, the similarity of strings "abc" and "abd" is 2, while the similarity of strings "aaa" and "aaab" is 3.

Calculate the sum of similarities of a string S with each of it's suffixes.

Input Format

The first line contains the number of test cases t. 
Each of the next t lines contains a string to process, .

Constraints

 is composed of characters in the range ascii[a-z]
Output Format

Output t lines, each containing the answer for the corresponding test case.

Sample Input

2
ababaa  
aa
Sample Output

11  
3
Explanation

For the first case, the suffixes of the string are "ababaa", "babaa", "abaa", "baa", "aa" and "a". The similarities of these strings with the string "ababaa" are 6,0,3,0,1, & 1 respectively. Thus, the answer is 6 + 0 + 3 + 0 + 1 + 1 = 11.

For the second case, the answer is 2 + 1 = 3.


 */

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