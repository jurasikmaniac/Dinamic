using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruskal
{
    class Solver
    {
        public Graph graph = new Graph();
        Graph skeleton = new Graph();
        List<GraphComponent> components;
        List<string[]> output = new List<string[]>();
        public void addEdge(Edge e)
        {
            graph.Add(e);
        }
        public List<string[]> getResult()
        {
            calc();
            return output;
        }
        private void updateOutput()
        {
            string[] s = new string[2];
            s[0] += skeleton.ToStringEdges();
            foreach (GraphComponent c in components)
            {
                s[1] += c.ToString();
            }
            s[1] += graph.ToStringVerticles();
            output.Add(s);
        }
        private void calc()
        {
            int n = graph.verticlesCount;
            components = new List<GraphComponent>();
            graph.Sort();
            updateOutput();
            Edge currentEdge = graph[0];
            graph.RemoveAt(0);
            components.Add(new GraphComponent(currentEdge));
            skeleton.Add(currentEdge);
            updateOutput();
            while (components[0].Count < n && graph.Count>0)
            {
                currentEdge = graph[0];
                graph.RemoveAt(0);
                HashSet<int> hsi = components.Find(x=>x.Contains(currentEdge));
                if (hsi==null)
                {
                    List<GraphComponent> connectedComponents = components.FindAll(x=>x.Connected(currentEdge));
                    switch (connectedComponents.Count)
                    {
                        case 0:
                            components.Add(new GraphComponent(currentEdge));
                            skeleton.Add(currentEdge);
                            break;
                        case 1:
                            connectedComponents[0].Add(currentEdge);
                            skeleton.Add(currentEdge);
                            break;
                        case 2:
                            connectedComponents[0].UnionWith(connectedComponents[1]);
                            components.Remove(connectedComponents[1]);
                            connectedComponents[0].Add(currentEdge);
                            break;
                        default:
                            break;
                    }
                    updateOutput();
                }


            }
        }
    }
}
