using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lepus
{
    class Program
    {        
        static void Main(string[] args)
        {
            int n = 0;
            string map = "";
            try
            {
                using (StreamReader sr = new StreamReader("lepus.in"))
                {
                    n = int.Parse(sr.ReadLine());
                    map = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            Solver s = new Solver(n, map);
            System.IO.File.WriteAllText(@"lepus.out", s.getAnsver().ToString());            
        }
    }

    class Solver
    {
        private string map;
        private int[] path;
        private int n;
        public Solver(int n, string map)
        {
            this.n = n;
            this.map = map.Substring(0, n);
            path = new int[map.Length];
        }
        public int getAnsver()
        {
            int v1, v2, v3;
            for (int i = 1; i < n; i++)
            {
                path[i] = getFieldValue(i);
                if (path[i] >=0)
                {
                    v1 = getPathValue(i - 1);
                    v2 = getPathValue(i - 3);
                    v3 = getPathValue(i - 5);

                    path[i] += Math.Max(v1, Math.Max(v2, v3));
                }
            }
            return path[n - 1] < 0 ? -1 : path[n - 1];
        }
        private int getFieldValue(int i)
        {
            if (i >= 0 && i < n)
            {
                switch (map[i])
                {
                    case '.': return 0;
                    case 'w': return int.MinValue;
                    case '\"': return 1;
                    default: return int.MinValue;
                }

            }
            return int.MinValue;

        }
        private int getPathValue(int i)
        {
            if (i >= 0 && i < n)
            {
                return path[i];
            }
            return int.MinValue;
        }
    }
}
