using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slalom
{
    class Program
    {
        static int INF = -100000;
        static void Main(string[] args)
        {
            //string[] readText;
            List<string> readText=new List<string>();
            int[,] map;
            int N = 0;

            System.IO.StreamReader file = new System.IO.StreamReader(@"slalom.in");
            //readText = File.ReadAllLines(@"slalom.in");
            readText.Add(file.ReadLine());
            N = Convert.ToInt32(readText[0]);
            for (int i = 0; i < N; i++)
            {
                readText.Add(file.ReadLine());
            }
            map = new int[N + 1, N + 1];
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    map[i, j] = INF;
                }
            }


            string[] buf;
            for (int i = 1; i < N + 1; i++)
            {
                buf = readText[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = buf.Length - 1; j >= 0; j--)
                {
                    map[i - j, i] = Convert.ToInt32(buf[j]);
                }
            }

            for (int i = 1; i < N + 1; i++)
            {
                for (int j = 1; j < N + 1; j++)
                {
                    if (!(i == 1 && j == 1))
                    {
                        int s1 = map[j, i] + map[j - 1, i - 1];
                        int s2 = map[j, i] + map[j, i - 1];

                        map[j, i] = Math.Max(s1, s2);
                    }
                }
            }
            int max = -100000;
            for (int i = 1; i < N + 1; i++)
            {
                if (map[i, N] > max)
                {
                    max = map[i, N];
                }
            }
            System.IO.File.WriteAllText(@"slalom.out", max.ToString());

        }
    }
}
