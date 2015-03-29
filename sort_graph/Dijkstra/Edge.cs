using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Edge
    {
        public int a;
        public int b;
        public int cost;
        public Edge(int Vfrom, int Vto, int value)
        {
            this.a = Vfrom;
            this.b = Vto;
            this.cost = value;
        }
    }
}
