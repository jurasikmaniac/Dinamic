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
        public Pair(int To, int Cost)
        {
            this.to = To;
            this.cost = Cost;
        }
    }
}
