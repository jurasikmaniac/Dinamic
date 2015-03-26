using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Multistep
{
    public class Graph
    {
        public List<Pair> pairs;
        public List<Vertex>[] vertexs;        

        public Graph(int Level)
        {
            pairs = new List<Pair>();
            vertexs = new List<Vertex>[Level];
            for (int i = 0; i < Level; i++)
            {
                vertexs[i] = new List<Vertex>();
            }
        }

        virtual public void addVertex(string Name, int Level)
        {
            if (searchVertexByName(Name) == null && Level < vertexs.Length)
            {
                vertexs[Level].Add(new Vertex(Name));
            }
        }

        virtual public void addPair(string From, string To, int Value)
        {
            Vertex f = this.searchVertexByName(From);
            Vertex t = this.searchVertexByName(To);
            if (f != null && t != null)
            {
                pairs.Add(new Pair(f, t, Value));
            }
        }
        
        virtual public Vertex searchVertexByName(string nameVertex)
        {
            Vertex temp = null;
            for (int i = 0; i < vertexs.Length; i++)
            {
                temp = vertexs[i].Where(I => I.name == nameVertex).FirstOrDefault<Vertex>();
                if (temp != null) return temp;
            }
            return temp;
        }        


    }
}
