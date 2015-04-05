using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knight
{
    class Program
    {
        static int N;
        static int M;
        static int[,] dp;
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"knight.in");
            string[] buf;
            buf = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            N = Convert.ToInt32( buf[0]);
            M = Convert.ToInt32(buf[1]);
            dp = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    dp[i, j] = -1;
                }
            }
            dp[0, 0] = 1;
            int count=solve(N - 1, M - 1);
            System.IO.File.WriteAllText(@"knight.out", count.ToString());

        }

        static int solve(int i, int j)
        {
            if (good(i, j))
            {
                if (dp[i,j] == -1)
                    dp[i,j] = solve(i - 1, j - 2) + solve(i - 2, j - 1);
            }
            else
                return 0;
            return dp[i,j];
        }

        static bool good(int i, int j)
        {
            return (i >= 0) && (j >= 0) && (i < N) && (j < M);
        }
    }
}
