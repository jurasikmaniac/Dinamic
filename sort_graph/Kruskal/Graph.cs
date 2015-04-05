using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruskal
{
    class Graph : List<Edge>
    {
        protected HashSet<int> verticles = new HashSet<int>();
        public int verticlesCount
        {
            get { return verticles.Count; }
        }
        public Graph()
        {

        }
        public Graph(Edge e)
        {
            Add(e);
        }
        public bool hasConnectionWith(Edge e)
        {
            return Find(x => x.connected(e)) != null;
        }
        new public void Add(Edge e)
        {
            if (!Contains(e))
            {
                base.Add(e);
                verticles.Add(e.v1);
                verticles.Add(e.v2);
            }
        }
        new public void RemoveAt(int i)
        {
            verticles.Remove(this[i].v1);
            verticles.Remove(this[i].v2);
            base.RemoveAt(i);
        }
        public string ToStringVerticles()
        {
            return String.Join(", ", verticles.ToArray());
        }
        public string ToStringEdges()
        {
            string s = "";
            foreach (Edge e in this)
            {
                s += e.ToString();
            }
            return s;
        }
    }
}
