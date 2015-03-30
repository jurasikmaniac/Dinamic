using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dijkstra
{
    public partial class Form1 : Form
    {
        List<Edge> edges;
        int n;//количество вершин        
        int s = 0;//номер стартовой вершины
        int t = 0;//номер конеччной вершины
        List<List<Pair>> g;
        const int INF = 1000000000;
        
        
        public Form1()
        {
            edges = new List<Edge>();
            edges.Add(new Edge(0, 1, 25));
            edges.Add(new Edge(0, 2, 15));
            edges.Add(new Edge(0, 3, 7));
            edges.Add(new Edge(0, 4, 2));
            edges.Add(new Edge(1, 2, 6));
            edges.Add(new Edge(2, 3, 4));
            edges.Add(new Edge(3, 4, 3));
            InitializeComponent();
            numericUpDown1.Value = Convert.ToDecimal(5);
            updateDataGrid();
        }

        private void updateDataGrid()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            if (edges != null)
            {
                foreach (var p in edges)
                {
                    dataGridView1.Rows.Add(new string[] { p.a.ToString(), p.b.ToString(), p.cost.ToString() });
                    i++;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edges.Add(new Edge(Convert.ToInt32(textBoxFrom.Text), Convert.ToInt32(textBoxTo.Text), Convert.ToInt32(textBox1.Text)));
            updateDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            edges = new List<Edge>();
            updateDataGrid();
        }

        private void Дейкстра()
        {
            g = new List<List<Pair>>();
            List<int> d = new List<int>();
            List<int> p = new List<int>();
            List<bool> u = new List<bool>();
            
            for (int i = 0; i < n; i++)
            {
                g.Add(new List<Pair>());
                d.Add(INF);
                p.Add(0);
                u.Add(false);
            }
            d[s] = 0;
            //чтение графа из списка рёбер
            foreach (var item in edges)
            {
                g[item.a].Add(new Pair(item.b, item.cost));
            }
           
            for (int i = 0; i < n; ++i)
            {
                int v = -1;
                for (int j = 0; j < n; ++j)
                    if (!u[j] && (v == -1 || d[j] < d[v]))
                        v = j;
                if (d[v] == INF)
                    break;
                u[v] = true;

                for (int j = 0; j < g[v].Count; ++j)
                {
                    int to = g[v][j].to,
                        len = g[v][j].cost;
                    if (d[v] + len < d[to])
                    {
                        d[to] = d[v] + len;
                        p[to] = v;
                    }
                    //для неориентированного графа
                    if (d[to] + len < d[v])
                    {
                        d[v] = d[to] + len;
                        p[v] = to;
                    }
                    
                }
                
            }
foreach (var item in d)
                    {
                        if (item==INF)
                        {
                            textBox2.Text +="INF" + " ";
                        }else
                        textBox2.Text += item.ToString() + " ";

                    }
                    textBox2.Text += Environment.NewLine;
            //foreach (var item in d)
            //{
            //    textBox2.Text += item.ToString() + " ";

            //}
            textBox2.Text += Environment.NewLine;
            if (t > n - 1)
            {
                textBox2.Text += "No path from " + s + " to " + t + "."; ;
            }
            else
            {
                if (d[t] == INF)
                    textBox2.Text += "No path from " + s + " to " + t + ".";
                else
                {
                    List<int> path = new List<int>();
                    for (int v = t; v != s; v = p[v])
                    {
                        path.Add(v);
                    }
                    path.Add(s);
                    path.Reverse();

                    textBox2.Text += "Path from " + s + " to " + t + ": ";
                    for (int i = 0; i < path.Count; ++i)
                    {
                        textBox2.Text += path[i] + " ";
                    }
                }
            }
            textBox2.Text += Environment.NewLine;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = Decimal.ToInt32(numericUpDown1.Value);
            s = Decimal.ToInt32(numericUpDown2.Value);
            t = Decimal.ToInt32(numericUpDown3.Value);
            Дейкстра();
        }

    }
}
