using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace king2
{
    class Program
    {
        static int INF = 1000000;
        static void Main(string[] args)
        {
            int[,] map = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    map[i, j] = INF;
                }
                
            }
            
            string[] readText = File.ReadAllLines(@"king2.in");
            string[] buf;
            for (int i = 7; i >= 0; i--)
            {
                buf = readText[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < buf.Length; j++)
                {
                    map[8 - i, j + 1] = Convert.ToInt32(buf[j]);
                }
            }

            for (int i = 1; i < 9; i++)
            {

                for (int j = 1; j < 9; j++)
                {
                    if (!(i == 1 && j == 1))
                    {
                        int s1 = map[i, j] + map[i - 1, j];
                        int s2 = map[i, j] + map[i - 1, j - 1];
                        int s3 = map[i, j] + map[i, j - 1];
                        map[i, j] = Math.Min(s1, Math.Min(s2, s3));
                    }                    
                }
            }
            System.IO.File.WriteAllText(@"king2.out", map[8, 8].ToString());
        }
    }
}
