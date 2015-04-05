using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Pair
    {
        public int to;
        public int cost;
        public Pair(int to, int cost)
        {
            this.to = to;
            this.cost = cost;
        }
    }
}
