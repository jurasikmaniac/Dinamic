using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruskal
{
    class GraphComponent : HashSet<int>
    {
        public GraphComponent() { }
        public GraphComponent(Edge e)
        {
            Add(e.v1);
            Add(e.v2);
        }
        public bool Contains(Edge e)
        {
            return Contains(e.v1) && Contains(e.v2);
        }
        public bool Connected(Edge e)
        {
            return !Contains(e) && (Contains(e.v1) || Contains(e.v2));
        }
        public void Add(Edge e)
        {
            Add(e.v1);
            Add(e.v2);
        }
        public override string ToString()
        {
            return "(" + String.Join(", ", this.ToArray()) + ")";
        }
    }
}
