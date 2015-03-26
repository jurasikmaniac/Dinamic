using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multistep
{
    public class Pair
    {
        public Vertex from;
        public Vertex to;
        public int value;

        public Pair(Vertex From, Vertex To, int Value)
        {
            this.from = From;
            this.to = To;
            this.value = Value;
        }
    }
}
