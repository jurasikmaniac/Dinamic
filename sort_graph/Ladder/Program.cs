using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladder
{
    class Program
    {
        static void Main(string[] args)
        {
            int Count = 0;
            List<int> A = new List<int>();
            List<int> B = new List<int>();
            string[] readText = File.ReadAllLines(@"ladder.in");
            string[] buf;
            B.Add(0);
            B.Add(0);
            
            try
            {
                Count = Convert.ToInt32(readText[0]);
                buf = readText[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in buf)
                {
                    A.Add(Convert.ToInt32(item));
                }
            }
            catch (Exception)
            {
                return;
            }

            for (int i = 0; i < Count; i++)
            {
                int Max=Math.Max(B[i]+A[i],B[i+1]+A[i]);
                B.Add(Max);
            }
            System.IO.File.WriteAllText(@"ladder.out", B[B.Count-1].ToString());
        }
    }
}
