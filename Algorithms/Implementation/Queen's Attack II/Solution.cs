//https://www.hackerrank.com/challenges/queens-attack-2/submissions
using System.IO;
using System;

class Solution
{

    // Complete the queensAttack function below.
    static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
    {
        //Row Column coordinates of the closes object in each direction
        int rRObstacle = -1;
        int cRObstacle = -1;
        int rBRObstacle = -1;
        int cBRObstacle = -1;
        int rBObstacle = -1;
        int cBObstacle = -1;
        int rBLObstacle = -1;
        int cBLObstacle = -1;
        int rLObstacle = -1;
        int cLObstacle = -1;
        int rTLObstacle = -1;
        int cTLObstacle = -1;
        int rTObstacle = -1;
        int cTObstacle = -1;
        int rTRObstacle = -1;
        int cTRObstacle = -1;

        //Total squares attacked by the queen
        int reachableSquares = 0;

        //Finds the closest object in each direction
        for (int a0 = 0; a0 < k; a0++)
        {
            int rObstacle = obstacles[a0][0];
            int cObstacle = obstacles[a0][1];

            //Right
            if ((cObstacle < cRObstacle || rRObstacle == -1) && cObstacle > c_q && rObstacle == r_q)
            {
                rRObstacle = rObstacle;
                cRObstacle = cObstacle;
            }

            //Bottom Right
            if (r_q - rObstacle == cObstacle - c_q && cObstacle > c_q && rObstacle < r_q
               && ((rObstacle > rBRObstacle && cObstacle < cBRObstacle) || rBRObstacle == -1))
            {
                rBRObstacle = rObstacle;
                cBRObstacle = cObstacle;
            }

            //Bottom    
            if ((rObstacle > rBObstacle || rBObstacle == -1) && rObstacle < r_q && cObstacle == c_q)
            {
                rBObstacle = rObstacle;
                cBObstacle = cObstacle;
            }

            //Bottom Left
            if (r_q - rObstacle == c_q - cObstacle && cObstacle < c_q && rObstacle < r_q
               && ((rObstacle > rBLObstacle && cObstacle > cBLObstacle) || rBLObstacle == -1))
            {
                rBLObstacle = rObstacle;
                cBLObstacle = cObstacle;
            }

            //Left
            if ((cObstacle > cLObstacle || rLObstacle == -1) && cObstacle < c_q && rObstacle == r_q)
            {
                rLObstacle = rObstacle;
                cLObstacle = cObstacle;
            }

            //Top Left
            if (c_q - cObstacle == rObstacle - r_q && cObstacle < c_q && rObstacle > r_q
               && ((rObstacle < rTLObstacle && cObstacle > cTLObstacle) || rTLObstacle == -1))
            {
                rTLObstacle = rObstacle;
                cTLObstacle = cObstacle;
            }

            //Top
            if ((rObstacle < rTObstacle || rTObstacle == -1) && rObstacle > r_q && cObstacle == c_q)
            {
                rTObstacle = rObstacle;
                cTObstacle = cObstacle;
            }

            //Top Right
            if (rObstacle - r_q == cObstacle - c_q && cObstacle > c_q
               && rObstacle > r_q && ((rObstacle < rTRObstacle && cObstacle < cTRObstacle) || rTRObstacle == -1))
            {
                rTRObstacle = rObstacle;
                cTRObstacle = cObstacle;
            }

        }

        //Calculates the distance to the closest obstacle in each direction and adds it to reachableSquares
        //R B L T
        reachableSquares += (cRObstacle != -1) ? (cRObstacle - c_q - 1) : n - c_q;
        reachableSquares += (rBObstacle != -1) ? (r_q - rBObstacle - 1) : r_q - 1;
        reachableSquares += (cLObstacle != -1) ? (c_q - cLObstacle - 1) : c_q - 1;
        reachableSquares += (rTObstacle != -1) ? (rTObstacle - r_q - 1) : n - r_q;

        //BR BL TL TR
        reachableSquares += (cBRObstacle != -1) ? (cBRObstacle - c_q - 1) : Math.Min(n - c_q, r_q - 1);
        reachableSquares += (rBLObstacle != -1) ? (c_q - cBLObstacle - 1) : Math.Min(c_q - 1, r_q - 1);
        reachableSquares += (cTLObstacle != -1) ? (c_q - cTLObstacle - 1) : Math.Min(c_q - 1, n - r_q);
        reachableSquares += (rTRObstacle != -1) ? (cTRObstacle - c_q - 1) : Math.Min(n - c_q, n - r_q);

        return reachableSquares;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        string[] r_qC_q = Console.ReadLine().Split(' ');

        int r_q = Convert.ToInt32(r_qC_q[0]);

        int c_q = Convert.ToInt32(r_qC_q[1]);

        int[][] obstacles = new int[k][];

        for (int i = 0; i < k; i++)
        {
            obstacles[i] = Array.ConvertAll(Console.ReadLine().Split(' '), obstaclesTemp => Convert.ToInt32(obstaclesTemp));
        }

        int result = queensAttack(n, k, r_q, c_q, obstacles);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}